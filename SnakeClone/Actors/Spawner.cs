﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public IGameElement Spawn()
        {
            return spawnerDelegate();
        }
    }
}