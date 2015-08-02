using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SnakeClone.Actors;
using SnakeClone.Actors.States;
using SnakeClone.Map;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static SnakeClone.Input.InputManager;
using Microsoft.Xna.Framework.Content;
using SnakeClone.Rendering;
using SnakeClone.Providers;

namespace SnakeClone
{
    internal class SnakeClone
    {
        private readonly Level level;
        private readonly List<IGameElement> elements = new List<IGameElement>();
        private readonly ReadOnlyCollection<AddState> directionStates;
        private readonly RenderContext renderContext;
        private readonly IAssetProvider assetProvider;

        public SnakeClone(ILevelProvider levelProvider, IAssetProvider assetProvider)
        {                 

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

        public void LoadContent(SpriteBatch batch, ContentManager content)
        {
            //renderContext = new RenderContext()
            //level = new Level(levelProvider,
        }

        public void HandleState()
        {
            foreach(var state in directionStates)
            {
                state.Check();
            }
        }

        public void Update(float deltaTime)
        {
            elements.ForEach(element => element.Update(deltaTime));
        }

        public void Render()
        {
            elements.ForEach(element => element.Render(renderContext));
        }

    }
}
