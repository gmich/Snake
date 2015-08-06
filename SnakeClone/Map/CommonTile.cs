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

        public bool Intersect(LevelContext context)
        {
            return false;
        }

        public void Render(RenderContext renderContext)
        {
            renderContext.RenderInGrid(transform);
        }
    }
}
