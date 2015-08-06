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
        private bool hasMoved;

        public SnakePiece(Transform transform)
        {
            this.transform = transform;
            location = transform.Location.AsPoint();
        }

        private SnakePiece Tail { get; set; }
        public bool HasTail { get { return Tail != null; } }
        public Vector2 HeadGridLocation { get { return location.AsVector2(); } }

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
            get
            {
                Point tailLocation = location;
                if (Tail != null)
                {
                    tailLocation = Tail.TailLocation;
                }
                return tailLocation;
            }
        }

        public void MoveTo(Func<Point, Point> newDirection)
        {
            MoveTo(newDirection(location));
        }

        private void MoveTo(Point newLocation)
        {
            Tail?.MoveTo(location);
            location = newLocation;
            transform = transform.Move(() => location.AsVector2());
            hasMoved = true;
        }

        public void Update(LevelContext context, double deltaTime)
        {
            CheckBodyCollision(Tail, context, location);
        }

        private void CheckBodyCollision(SnakePiece piece, LevelContext context, Point locationToTest)
        {
            if (piece != null)
            {
                if (locationToTest == piece.location)
                {
                    if (piece.hasMoved)
                    {
                        context.AddState(new DeathState());
                    }
                }
                CheckBodyCollision(piece.Tail,context, locationToTest);
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
                if (Tail != null)
                {
                    return Tail.Intersects(otherLocation);
                }
            }
            return false;
        }

        public void Render(RenderContext renderContext)
        {
            renderContext.RenderInGrid(transform);
            Tail?.Render(renderContext);
        }

    }
}
