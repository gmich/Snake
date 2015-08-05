using Microsoft.Xna.Framework.Graphics;
using SnakeClone.Actors;
using SnakeClone.Actors.States;
using SnakeClone.Map;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework.Content;
using SnakeClone.Rendering;
using SnakeClone.Providers;
using static SnakeClone.Input.InputManager;
using System;

namespace SnakeClone
{
    internal class SnakeClone
    {
        private readonly List<IGameElement> elements = new List<IGameElement>();
        private readonly ReadOnlyCollection<AddState> directionStates;
        private readonly IAssetProvider assetProvider;
        private readonly ILevelTracker levelTracker;

        private RenderContext renderContext;
        private Level level;
        private double passedTime;

        public SnakeClone(ILevelTracker levelTracker, IAssetProvider assetProvider)
        {
            this.assetProvider = assetProvider;
            this.levelTracker = levelTracker;
            directionStates = new ReadOnlyCollection<AddState>(new List<AddState>
            {
                AddState.To(()=>level.Context.AddState(new ChangeDirectionState(Direction.Up)))
                        .When(() => Keyboard.IsKeyClicked(InputKeys.Up)),
                AddState.To(()=>level.Context.AddState(new ChangeDirectionState(Direction.Down)))
                        .When(() => Keyboard.IsKeyClicked(InputKeys.Down)),
                AddState.To(()=>level.Context.AddState(new ChangeDirectionState(Direction.Left)))
                        .When(() => Keyboard.IsKeyClicked(InputKeys.Left)),
                AddState.To(()=>level.Context.AddState(new ChangeDirectionState(Direction.Right)))
                        .When(() => Keyboard.IsKeyClicked(InputKeys.Right))

            });
          
        }

        public void Restart() 
        {
            level = new Level(levelTracker.Current,NextLevel,Restart);
        }

        public void NextLevel()
        {
            level = new Level(levelTracker.Current, NextLevel, Restart);
        }

        public void LoadContent(SpriteBatch batch, ContentManager content)
        {
            var textureContainer = new AssetContainer<Func<Texture2D>>(content);
            assetProvider.LoadAssets(textureContainer);
            renderContext = new RenderContext(assetProvider.RenderInfo, batch, textureContainer);
        }

        public void HandleState()
        {
            if (level.Settings.SnakeSpeed < passedTime)
            {
                foreach (var state in directionStates)
                {
                    state.Check();
                }
                passedTime = 0.0d;
            }
        }

        public void Update(double deltaTime)
        {
            passedTime += deltaTime;
            elements.ForEach(element => element.Update(deltaTime));
        }

        public void Render()
        {
            elements.ForEach(element => element.Render(renderContext));
        }

    }
}
