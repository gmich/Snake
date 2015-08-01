using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeClone.Map
{
    interface IMapGenerator
    {
        ITile[,] Generate();
    }
}
