using Microsoft.Xna.Framework;
using SnakeClone.Actors;
using SnakeClone.Providers;
using SnakeClone.Rendering;
using System;
using System.Collections.Generic;
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
        private readonly List<IGameElement> elements = new List<IGameElement>();

        public Level(ILevelProvider levelProvider, Action next, Action restart)
        {
            this.levelProvider = levelProvider;
            grid = levelProvider.Grid;
            levelSettings = levelProvider.LevelSettings;
            adjustmentRules = AdjustmentRules.Default(levelProvider.LevelSettings.HorizontalTileCount-1,
                                                           levelProvider.LevelSettings.VerticalTileCount-1);

            context = new LevelContext(levelProvider.Head,
                                       levelProvider.TailSpawner,
                                       Direction.Left,
                                       restart,
                                       next,
                                       levelProvider.LevelSettings.MaxLives);
            elements.Add(levelProvider.Head);
        }


        public LevelContext Context { get { return context; } }

        public LevelSettings Settings { get { return levelSettings; } }

        public Point AdjustInGrid(Point other)
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

        public void Update(double deltaTime)
        {
            elements.ForEach(element => element.Update(deltaTime));
        }

        public void Render(RenderContext context)
        {
            for (int x = 0; x < levelSettings.HorizontalTileCount; x++)
            {
                for (int y = 0; y < levelSettings.VerticalTileCount; y++)
                {
                    grid[x, y].Render(context);
                    //context.Batch.DrawString(context.FontContainer["menuFont"],
                    //    x + " " + y,
                    //    new Vector2(x * context.LevelRenderInfo.TileWidth, y * context.LevelRenderInfo.TileHeight),
                    //    Color.Black);
                }
            }
            elements.ForEach(element => element.Render(context));

        }

    }
}
