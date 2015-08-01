using SnakeClone.Actors.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeClone.Map
{
    class DeathTile : ITile
    {
        public void Intersect(LevelContext context)
        {
            context.AddState(new DeathState());
        }
    }
}
