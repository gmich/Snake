using SnakeClone.Rendering;
using System;
using Microsoft.Xna.Framework;
using SnakeClone.Map;
using SnakeClone.Actors.States;

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
            if(transform.Location==context.SnakeHead.HeadGridLocation)
            {
                context.AddState(new AddTailState());
                disposable.Dispose();
            }
        }

        public void Render(RenderContext renderContext)
        {
            renderContext.RenderInGrid(transform);
        }

        public bool Intersects(Vector2 otherLocation)
        {
            return ((transform.Location.X == otherLocation.X)
                || (transform.Location.Y == otherLocation.Y));
        }
    }
}
