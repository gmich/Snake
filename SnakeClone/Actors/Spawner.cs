using System;

namespace SnakeClone.Actors
{
    internal class Spawner<TElement> 
        where TElement : IGameElement
    {

        private readonly Func<TElement> spawnerDelegate;

        public Spawner(Func<TElement> spawnerDelegate)
        {
            this.spawnerDelegate = spawnerDelegate;
        }

        public TElement Spawn()
        {
            return spawnerDelegate();
        }
    }
}
