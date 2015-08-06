using SnakeClone.Map;
using Microsoft.Xna.Framework;
using SnakeClone.Rendering;
using SnakeClone.Actors;

namespace SnakeClone.Providers
{
    internal class HardCodedLevelProvider : ILevelProvider
    {
        private readonly SnakePiece head;
        private readonly Spawner<SnakePiece> tailSpawner;

        public HardCodedLevelProvider()
        {
            tailSpawner = new Spawner<SnakePiece>(position =>
                        new SnakePiece(
                            new Transform(
                            () => new Color(12.0f, 12.0f, 12.0f),
                            () => "snakeHead",
                            () => Vector2.One,
                            () => new Vector2(LevelSettings.SnakeInitialPosition.X, LevelSettings.SnakeInitialPosition.Y),
                            () => 0.0f,
                            () => 0.0f)));

            head = new SnakePiece(new Transform(
                            () => Color.BlueViolet,
                            () => "snakeHead",
                            () => Vector2.One,
                            () => new Vector2(LevelSettings.SnakeInitialPosition.X, LevelSettings.SnakeInitialPosition.Y),
                            () => 0.0f,
                            () => 0.0f));
        }

        public LevelSettings LevelSettings
        { get; } = new LevelSettings(20, 20, new RandomFoodFactory(), new Point(5, 5), 0.1d, 3);

        public ITile[,] Grid
        {
            get
            {
                ITile[,] grid = new ITile[LevelSettings.HorizontalTileCount, LevelSettings.VerticalTileCount];

                for (int x = 0; x < LevelSettings.HorizontalTileCount; x++)
                {
                    for (int y = 0; y < LevelSettings.VerticalTileCount; y++)
                    {
                        var location = new Vector2(x ,y);
                        grid[x, y] = new CommonTile(new Transform(
                            () => new Color(26.0f, 188.0f, 156.0f),
                            () => AssetReference.WhitePixel,
                            () => Vector2.One,
                            () => location,
                            () => 0.0f,
                            () => 0.0f));
                    }
                }
                return grid;
            }
        }

        public SnakePiece Head
        {
            get { return head; }
        }

        public Spawner<SnakePiece> TailSpawner
        {
            get { return tailSpawner; }
        }
    }
}
