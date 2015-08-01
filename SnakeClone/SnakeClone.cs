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

namespace SnakeClone
{
    class SnakeClone
    {
        private readonly Level level;
        private LevelContext context;
        private readonly List<IGameElement> elements = new List<IGameElement>();
        private readonly SnakePiece snake;
        private readonly ReadOnlyCollection<AddState> directionStates;


        #region Direction Helper Class
        private class AddState
        {
            private readonly Action newDirection;
            private Func<bool> condition;

            private AddState(Action newDirection)
            {
                this.newDirection = newDirection;
            }
            public static AddState To(Action newDirection)
            {
                return new AddState(newDirection);
            }
            public AddState When(Func<bool> condition)
            {
                this.condition = condition;
                return this;
            }

            public void Check()
            {
                if (condition())
                {
                    newDirection();
                }
            }

        }

        #endregion


        public SnakeClone(GameType gameType)
        {
            level = new Level(new BlankMapGenerator(gameType.SizeX, gameType.SizeY),
                              AdjustmentRules.Default(gameType.SizeX, gameType.SizeY));
            elements.Add(snake);

            directionStates = new ReadOnlyCollection<AddState>(new List<AddState>
            {
                AddState.To(()=>context.AddState(new ChangeDirectionState(Direction.Up)))
                        .When(() => Keyboard.IsKeyClicked(InputKeys.Up)),
                AddState.To(()=>context.AddState(new ChangeDirectionState(Direction.Down)))
                        .When(() => Keyboard.IsKeyClicked(InputKeys.Down)),
                AddState.To(()=>context.AddState(new ChangeDirectionState(Direction.Left)))
                        .When(() => Keyboard.IsKeyClicked(InputKeys.Left)),
                AddState.To(()=>context.AddState(new ChangeDirectionState(Direction.Right)))
                        .When(() => Keyboard.IsKeyClicked(InputKeys.Right))

            });
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

        public void Render(SpriteBatch batch)
        {

        }

    }
}
