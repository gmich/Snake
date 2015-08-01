using SnakeClone.Map;

namespace SnakeClone.Actors.States
{
    class DeathState : ISnakeState
    {
        public void Handle(LevelContext context)
        {
            context.Lives--;
            context.RestartLevel();
        }
    }
}
