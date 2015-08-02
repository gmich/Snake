﻿using SnakeClone.Map;

namespace SnakeClone.Actors.States
{
    class ChangeDirectionState : ISnakeState
    {
        private readonly Direction direction;
        public ChangeDirectionState(Direction newDirection)
        {
            this.direction = newDirection;
        }
        public void Handle(LevelContext context)
        {
            context.Direction = direction;
        }
    }
}