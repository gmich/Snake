using SnakeClone.Rendering;

namespace SnakeClone.Map
{
    internal class CommonTile : ITile
    {

        private readonly Transform transform;

        public CommonTile(Transform transform)
        {
            this.transform = transform;
        }

        public void Intersect(LevelContext context)
        {
            return;
        }

        public void Render(RenderContext renderContext)
        {
            renderContext.RenderInGrid(transform);
        }
    }
}
