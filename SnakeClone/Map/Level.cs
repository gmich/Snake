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
            adjustmentRules = AdjustmentRules.Default(levelProvider.LevelSettings.HorizontalTileCount - 1,
                                                           levelProvider.LevelSettings.VerticalTileCount - 1);

            context = new LevelContext(levelProvider.Head,
                                       levelProvider.LevelSettings,
                                       levelProvider.TailSpawner,
                                       Direction.Left,
                                       restart,
                                       next,
                                       location =>
                                       {
                                           bool intersects = grid[(int)location.X, (int)location.Y].Intersect(context);
                                           elements.ForEach(element => intersects|= element.Intersects(location));
                                           return intersects;
                                       },
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
            var element = levelProvider.ElementSpawner.Create(context, elements, deltaTime);
            if (element != null) elements.Add(element);

            elements.ForEach(elemnt => elemnt.Update(context,deltaTime));

            var headLocation = context.SnakeHead.HeadGridLocation.AsPoint();
            grid[headLocation.X, headLocation.Y].Intersect(context);
          

        }

        public void Render(RenderContext context)
        {
            for (int x = 0; x < levelSettings.HorizontalTileCount; x++)
            {
                for (int y = 0; y < levelSettings.VerticalTileCount; y++)
                {
                    grid[x, y].Render(context);
                }
            }
            elements.ForEach(element => element.Render(context));

        }

    }
}
