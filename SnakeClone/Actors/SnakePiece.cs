using Microsoft.Xna.Framework;
using SnakeClone.Rendering;

namespace SnakeClone.Actors
{
    internal class SnakePiece : IGameElement
    {
        private readonly Transform transform;
        private Point location;

        public SnakePiece(Transform transform)
        {
            this.transform = transform;
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

        public void MoveTo(Point newLocation)
        {
            Tail?.MoveTo(location);
            location = newLocation;
        }

        public void Render(RenderContext renderContext)
        {
            //render local
            Tail?.Render(renderContext);
        }

        public void Update(float deltaTime)
        {
            //update local
            Tail?.Update(deltaTime);
        }

    }
}
