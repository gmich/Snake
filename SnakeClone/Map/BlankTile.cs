using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeClone.Map
{
    class BlankTile : ITile
    {
        public void Intersect(LevelContext context)
        {
            return;
        }
    }
}
