using System;

namespace SnakeClone.Actors.States
{
    internal class AddState
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
}
