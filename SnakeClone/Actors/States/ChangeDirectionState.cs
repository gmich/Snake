using SnakeClone.Map;

namespace SnakeClone.Actors.States
{
    internal class ChangeDirectionState : ISnakeState
    {
        private readonly Direction direction;

        public ChangeDirectionState(Direction newDirection)
        {
            direction = newDirection;
        }

        public void Handle(LevelContext context)
        {
            context.Direction = direction;
        }
    }
}
