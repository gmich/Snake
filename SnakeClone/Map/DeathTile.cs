using SnakeClone.Actors.States;
using SnakeClone.Rendering;

namespace SnakeClone.Map
{
    internal class DeathTile : ITile
    {
        private readonly Transform transform;

        public DeathTile(Transform transform)
        {
            this.transform = transform;
        }

        public void Intersect(LevelContext context)
        {
            context.AddState(new DeathState());
        }

        public void Render(RenderContext context)
        {
            context.RenderInGrid(transform);
        }
    }
}
