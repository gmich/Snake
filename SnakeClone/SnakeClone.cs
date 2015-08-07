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
        private Action onContinuePlaying;
        private readonly List<RenderedMessage> messages = new List<RenderedMessage>();

        public SnakeClone(Action<Vector2> configureLevelSize, ILevelTracker levelTracker, IAssetProvider assetProvider, SpriteBatch batch, ContentManager content)
        {
            this.assetProvider = assetProvider;
            this.levelTracker = levelTracker;
            this.configureLevelSize = configureLevelSize;
            AddMessages(new RenderedMessage(() => "snake", new Color(44, 62, 80)),
                        new RenderedMessage(()=>"\n\n{arrow keys}", new Color(241, 196, 15)),
                        new RenderedMessage(() => "\n\n\n\nto navigate", new Color(240, 240, 241)),
                        new RenderedMessage(() => "\n\n\n\n\n\n\n{enter}", new Color(241, 196, 15)),
                        new RenderedMessage(() => "\n\n\n\n\n\n\n\n\nto play", new Color(240, 240, 241)),
                        new RenderedMessage(() => "\n\n\n\n\n\n\n\n\n\n\n\n{escape}", new Color(241, 196, 15)),
                        new RenderedMessage(() => "\n\n\n\n\n\n\n\n\n\n\n\n\n\nto quit", new Color(240, 240, 241)));


            onContinuePlaying = () => NewLevel(levelTracker.Next);

            directionStates = new ReadOnlyCollection<AddState>(new List<AddState>
            {
                AddState.To(()=>level.Context.ChangeDirection(new ChangeDirectionState(Direction.Up)))
                        .When(() => Keyboard.IsKeyClicked(InputKeys.Up)
                        && (level.Context.Direction != Direction.Down || !level.Context.SnakeHead.HasTail)),
                AddState.To(()=>level.Context.ChangeDirection(new ChangeDirectionState(Direction.Down)))
                        .When(() => Keyboard.IsKeyClicked(InputKeys.Down)
                        && (level.Context.Direction != Direction.Up || !level.Context.SnakeHead.HasTail)),
                AddState.To(()=>level.Context.ChangeDirection(new ChangeDirectionState(Direction.Left)))
                        .When(() => Keyboard.IsKeyClicked(InputKeys.Left)
                        && (level.Context.Direction != Direction.Right || !level.Context.SnakeHead.HasTail)),
                AddState.To(()=>level.Context.ChangeDirection(new ChangeDirectionState(Direction.Right)))
                        .When(() => Keyboard.IsKeyClicked(InputKeys.Right)
                        && (level.Context.Direction != Direction.Left || !level.Context.SnakeHead.HasTail))
            });

            var textureContainer = new AssetContainer<Func<Texture2D>>(content);
            var fontContainer = new AssetContainer<SpriteFont>(content);
            assetProvider.LoadAssets(textureContainer, fontContainer);
            renderContext = new RenderContext(assetProvider.RenderInfo, batch, textureContainer, fontContainer);
            NextLevel();
        }

        #region Properties

        public Level Level { get { return level; } }

        public GameState GameState { get; set; }

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

        #endregion

        public void Pause(params RenderedMessage[] reasons)
        {
            GameState = GameState.Paused;
            AddMessages(reasons);
        }

        private void AddMessages(params RenderedMessage[] reasons)
        {
            messages.Clear();
            foreach (var reason in reasons)
            {
                messages.Add(reason);
            }
        }

        public IEnumerable<RenderedMessage> Messages { get { return messages; } }
        
        public void Restart()
        {
            Pause(new RenderedMessage(() => level.Context.Score.ToString(), new Color(44, 62, 80)),
                  new RenderedMessage(() => "\n\n\n{enter}", new Color(241, 196, 15)));
            onContinuePlaying = () => NewLevel(levelTracker.Current);
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
            if (GameState!= GameState.Playing)
            {
                if (Keyboard.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.Enter))
                {
                    GameState = GameState.Playing;
                    AddMessages(new RenderedMessage(() => level.Context.Score.ToString(),
                                                    new Color(44, 62, 80)));
                    onContinuePlaying();
                }
                return;
            }

            passedTime += deltaTime;

            if (level.Settings.SnakeSpeed < passedTime)
            {
                var directionState = level.Context.GetDirection();
                if (directionState != null)
                {
                    directionState.Handle(level.Context);
                }
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
            if (GameState == GameState.NewGame) return;
            level.Render(renderContext);
        }

    }
}
