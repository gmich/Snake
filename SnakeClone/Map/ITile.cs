using SnakeClone.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeClone.Map
{
    public interface ITile
    {
        void Intersect(LevelContext context);

    }
}
