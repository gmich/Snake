using Microsoft.Xna.Framework;
using SnakeClone.Actors.States;
using SnakeClone.Map;
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
        public Vector2 HeadGridLocation {  get { return location.AsVector2(); } }

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

        public void MoveTo(Func<Point, Point> newDirection)
        {
            Tail?.MoveTo(location);
            MoveTo(newDirection(location));
        }

        private void MoveTo(Point newLocation)
        {
            location = newLocation;
            transform = transform.Move(() => location.AsVector2());
        }

        public void Render(RenderContext renderContext)
        {
            renderContext.RenderInGrid(transform);
            Tail?.Render(renderContext);
        }

        public void Update(LevelContext context, double deltaTime)
        {
            //Tail?.Update(context, deltaTime);
            if (context.IsCellDamageable(location.AsVector2()))
            {
                context.AddState(new DeathState());
            }
        }

        public bool Intersects(Vector2 otherLocation)
        {
            if ((location.X == otherLocation.X) || (location.Y == otherLocation.Y))
            {
                return true;
            }
            else
            {
                if(Tail!= null) return Tail.Intersects(otherLocation);
            }
            return false;
        }

    }
}
