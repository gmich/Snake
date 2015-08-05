using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SnakeClone.Actors;
using SnakeClone.Providers;
using SnakeClone.Rendering;
using System;
using System.Diagnostics.Contracts;

namespace SnakeClone.Map
{
    internal class Level
    {
        private readonly ITile[,] grid;
        private readonly AdjustmentRules adjustmentRules;
        private readonly LevelContext context;
        private readonly LevelSettings levelSettings;
        private readonly ILevelProvider levelProvider;
        public Level(ILevelProvider levelProvider,Action next, Action restart)
        {
            this.levelProvider = levelProvider;
            grid = levelProvider.Grid;
            levelSettings = levelProvider.LevelSettings;
            adjustmentRules = AdjustmentRules.Default(levelProvider.LevelSettings.HorizontalTileCount,
                                                           levelProvider.LevelSettings.VerticalTileCount);

            context = new LevelContext(levelProvider.Head,
                                       levelProvider.TailSpawner,
                                       Direction.Left,
                                       restart,
                                       next,
                                       levelProvider.LevelSettings.MaxLives);

        }


        public LevelContext Context { get { return context; } }

        public LevelSettings Settings { get { return levelSettings; } }

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
