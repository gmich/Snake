using SnakeClone.Rendering;
using System;
using Microsoft.Xna.Framework;
using SnakeClone.Map;
using SnakeClone.Actors.States;
using Microsoft.Xna.Framework.Graphics;

namespace SnakeClone.Actors
{
    internal class Food : IGameElement
    {
        private readonly Transform transform;
        private readonly double aliveTime;
        private IDisposable disposable;
        private double passedTime;

        public Food(double aliveTime, Transform transform)
        {
            this.transform = transform;
            this.aliveTime = aliveTime;
        }

        public void SetDisposable(IDisposable disposable)
        {
            this.disposable = disposable;
        }

        public void Update(LevelContext context, double deltaTime)
        {
            passedTime += deltaTime;
            if (passedTime >= aliveTime)
            {
                disposable.Dispose();
            }
            if (transform.Location == context.SnakeHead.HeadGridLocation)
            {
                context.AddState(new AddTailState());
                disposable.Dispose();
            }
        }

        public void Render(RenderContext renderContext)
        {
            int rectangleOffSet = renderContext.LevelRenderInfo.TileWidth / 5;

            renderContext.Batch.Draw(renderContext.TextureContainer[transform.TextureReference](),
            new Rectangle((int)transform.Location.X * renderContext.LevelRenderInfo.TileWidth + rectangleOffSet,
                          (int)transform.Location.Y * renderContext.LevelRenderInfo.TileHeight + rectangleOffSet,
                          renderContext.LevelRenderInfo.TileWidth - rectangleOffSet * 2,
                          renderContext.LevelRenderInfo.TileHeight - rectangleOffSet * 2),
            null,
            transform.Color,
            transform.Rotation,
            Vector2.Zero,
            SpriteEffects.None,
            0.0f);
        }

        public bool Intersects(Vector2 otherLocation)
        {
            return ((transform.Location.X == otherLocation.X)
                || (transform.Location.Y == otherLocation.Y));
        }
    }
}
