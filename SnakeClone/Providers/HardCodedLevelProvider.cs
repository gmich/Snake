using SnakeClone.Map;
using Microsoft.Xna.Framework;

namespace SnakeClone.Providers
{
    internal class HardCodedMapProvider : ILevelProvider
    {

        public LevelSettings LevelSettings
        { get; } = new LevelSettings(30, 30, new RandomFoodFactory(), new Point(5, 5), 1.0d);

        public ITile[,] Grid
        {
            get
            {
                ITile[,] grid = new ITile[LevelSettings.HorizontalTileCount, LevelSettings.VerticalTileCount];

                for (int x = 0; x < LevelSettings.HorizontalTileCount; x++)
                {
                    for (int y = 0; y < LevelSettings.VerticalTileCount; y++)
                        grid[x, y] = new BlankTile();
                }
                return grid;
            }
        }

    }
}
