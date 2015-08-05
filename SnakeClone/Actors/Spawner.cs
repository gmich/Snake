using Microsoft.Xna.Framework;
using System;

namespace SnakeClone.Actors
{
    internal class Spawner<TElement>
        where TElement : IGameElement
    {
        private readonly Func<Vector2, TElement> spawnerDelegate;

        public Spawner(Func<Vector2, TElement> spawnerDelegate)
        {
            this.spawnerDelegate = spawnerDelegate;
        }

        public TElement Spawn(Vector2 position)
        {
            return spawnerDelegate(position);
        }
    }
}
