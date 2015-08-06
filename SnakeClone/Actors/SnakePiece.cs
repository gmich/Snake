using Microsoft.Xna.Framework;
using SnakeClone.Rendering;
using System;

namespace SnakeClone.Actors
{
    internal class SnakePiece : IGameElement
    {
        private Transform transform;
        private Point location;

        public SnakePiece(Transform transform)
        {
            this.transform = transform;
            location = transform.Location.AsPoint();
        }

        private SnakePiece Tail { get; set; }
        private bool HasTail { get { return Tail != null; } }

        public void Bind(SnakePiece tail)
        {
            if (!HasTail)
            {
                Tail = tail;
            }
            else
            {
                Tail.Bind(tail);
            }
        }

        public Point TailLocation
        {
            get { return Tail?.location ?? location; }
        }

        public void MoveTo(Func<Point,Point> newDirection)
        {
            Tail?.MoveTo(location);
            MoveTo(newDirection(location));
        }

        private void MoveTo(Point newLocation)
        {
            location = newLocation;
            transform = transform.Move(() => newLocation.AsVector2());
        }

        public void Render(RenderContext renderContext)
        {
            renderContext.RenderInGrid(transform);
            Tail?.Render(renderContext);
        }

        public void Update(double deltaTime)
        {
            Tail?.Update(deltaTime);
        }

    }
}
