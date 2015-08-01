using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SnakeClone.Rendering;

namespace SnakeClone.Actors
{
    internal class Snake : IGameElement
    {
        private Point location;
        public Snake(Transform transform)
        {

        }

        public void Bind(Snake tail)
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
        private Snake Tail { get; set; }

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

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

    }
}
