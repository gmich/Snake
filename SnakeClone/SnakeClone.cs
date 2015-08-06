using Microsoft.Xna.Framework.Graphics;
using SnakeClone.Actors;
using SnakeClone.Actors.States;
using SnakeClone.Map;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework.Content;
using SnakeClone.Rendering;
using SnakeClone.Providers;
using System;
using Microsoft.Xna.Framework;
using static SnakeClone.Input.InputManager;

namespace SnakeClone
{
    internal class SnakeClone
    {
        private readonly ReadOnlyCollection<AddState> directionStates;
        private readonly IAssetProvider assetProvider;
        private readonly ILevelTracker levelTracker;
        private readonly Action<Vector2> configureLevelSize;
        private RenderContext renderContext;
        private Level level;
        private double passedTime;

        public SnakeClone(Action<Vector2> configureLevelSize, ILevelTracker levelTracker, IAssetProvider assetProvider, SpriteBatch batch, ContentManager content)
        {
            this.assetProvider = assetProvider;
            this.levelTracker = levelTracker;
            this.configureLevelSize = configureLevelSize;
            directionStates = new ReadOnlyCollection<AddState>(new List<AddState>
            {
                AddState.To(()=>level.Context.AddState(new ChangeDirectionState(Direction.Up)))
                        .When(() => Keyboard.IsKeyClicked(InputKeys.Up)
                        && (level.Context.Direction != Direction.Down || !level.Context.SnakeHead.HasTail)),
                AddState.To(()=>level.Context.AddState(new ChangeDirectionState(Direction.Down)))
                        .When(() => Keyboard.IsKeyClicked(InputKeys.Down)
                        && (level.Context.Direction != Direction.Up || !level.Context.SnakeHead.HasTail)),
                AddState.To(()=>level.Context.AddState(new ChangeDirectionState(Direction.Left)))
                        .When(() => Keyboard.IsKeyClicked(InputKeys.Left)
                        && (level.Context.Direction != Direction.Right || !level.Context.SnakeHead.HasTail)),
                AddState.To(()=>level.Context.AddState(new ChangeDirectionState(Direction.Right)))
                        .When(() => Keyboard.IsKeyClicked(InputKeys.Right)
                        && (level.Context.Direction != Direction.Left || !level.Context.SnakeHead.HasTail))
            });

            var textureContainer = new AssetContainer<Func<Texture2D>>(content);
            var fontContainer = new AssetContainer<SpriteFont>(content);
            assetProvider.LoadAssets(textureContainer, fontContainer);
            renderContext = new RenderContext(assetProvider.RenderInfo, batch, textureContainer, fontContainer);
            NextLevel();
        }

        public Level Level {  get { return level; } }

        public RenderContext RenderContext
        {
            get { return renderContext; }
        }

        private Vector2 LevelSize
        {
            get
            {
                return new Vector2(level.Settings.HorizontalTileCount * renderContext.LevelRenderInfo.TileWidth,
                                  (level.Settings.VerticalTileCount * renderContext.LevelRenderInfo.TileHeight));
            }
        }

        public void Restart()
        {
            NewLevel(levelTracker.Current);
        }

        public void NextLevel()
        {
            NewLevel(levelTracker.Next);
        }

        private void NewLevel(ILevelProvider provider)
        {
            level = new Level(provider, NextLevel, Restart);
            configureLevelSize(LevelSize);
        }

        public void HandleState()
        {
            ISnakeState state = null;
            while ((state = level.Context.GetState()) != null)
            {
                state.Handle(level.Context);
            }
        }

        public void Update(double deltaTime)
        {
            passedTime += deltaTime;

            if (level.Settings.SnakeSpeed < passedTime)
            {
                passedTime = 0.0d;

                level.Context.SnakeHead.MoveTo(point =>
                level.AdjustInGrid(
                    level.Context.Direction.Move(point)));
            }
            foreach (var state in directionStates)
            {
                state.Check();
            }

            HandleState();
            level.Update(deltaTime);
        }

        public void Render()
        {
            level.Render(renderContext);
        }

    }
}
