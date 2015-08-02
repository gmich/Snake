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

        public Level(ILevelProvider levelProvider, AssetContainer<Func<Texture2D>> assetContainer)
        {
            grid = levelProvider.Grid;
            levelSettings = levelProvider.LevelSettings;
            adjustmentRules = AdjustmentRules.Default(levelProvider.LevelSettings.HorizontalTileCount,
                                                           levelProvider.LevelSettings.VerticalTileCount);
            //context = new LevelContext(new SnakePiece(new Transform(()=>assetContainer["snakeHead"].))
            
        }
        public LevelContext Context { get { return context; } }


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
