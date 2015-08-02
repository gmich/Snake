using SnakeClone.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnakeClone.Actors
{
    internal class Food : IGameElement
    {
        private readonly Transform transform;

        public Food(Transform transform)
        {
            this.transform = transform;
        }

        public void Update(float deltaTime)
        {
            return;
        }

        public void Render(RenderContext renderContext)
        {
            renderContext.Batch.Draw(transform.Texture,
                new Rectangle((int)transform.Location.X * renderContext.LevelRenderInfo.TileWidth,
                              (int)transform.Location.Y * renderContext.LevelRenderInfo.TileHeight,
                              renderContext.LevelRenderInfo.TileWidth,
                              renderContext.LevelRenderInfo.TileHeight),
                null,
                transform.Color,
                transform.Rotation,
                Vector2.Zero,
                SpriteEffects.None,
                0.0f);
        }

    }
}
