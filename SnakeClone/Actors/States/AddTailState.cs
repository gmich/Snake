using SnakeClone.Map;

namespace SnakeClone.Actors.States
{
    internal class AddTailState : ISnakeState
    {
        public void Handle(LevelContext context)
        {
            context.SnakeHead.Bind(context.TailSpawner.Spawn(context.
                SnakeHead.
                TailLocation
                .AsVector2()));
            context.Score++;
        }
    }
}
