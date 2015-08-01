using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SnakeClone.Rendering;

namespace SnakeClone.Actors
{
    internal class SnakePiece : IGameElement
    {
        private Point location;
        public SnakePiece(Transform transform)
        {

        }

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

        public void Move(Point newLocation)
        {
            if(HasTail)
            {
                Tail.location = location;
            }
            location = newLocation;
        }

        private bool HasTail { get { return Tail != null; } }
        private SnakePiece Tail { get; set; }

        public void Render(SpriteBatch batch)
        {
            if (HasTail)
            {
                Tail.Render(batch);
            }
        }

        public void HandleState()
        {
            throw new NotImplementedException();
        }

        public void Update(float deltaTime)
        {
            throw new NotImplementedException();
        }

    }
}
