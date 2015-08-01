using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace SnakeClone.Map
{
    class Level
    {
        private readonly ITile[,] grid;
        private readonly AdjustmentRules adjustmentRules;

        public Level(IMapGenerator generator, AdjustmentRules adjustmentRules)
        {
            grid = generator.Generate();
            this.adjustmentRules = adjustmentRules;
        }

        public Point AdjustLocation(Point other)
        {
            return adjustmentRules.Apply(other); 
        }

        public ITile this[Point point]
        {
            get
            {
                Contract.Requires(point.X <= grid.GetLength(0));
                Contract.Requires(point.Y <= grid.GetLength(1));

                return grid[point.X, point.Y];
            }
        }
        
    }
}
