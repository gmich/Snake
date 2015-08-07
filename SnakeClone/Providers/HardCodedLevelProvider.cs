using SnakeClone.Map;
using Microsoft.Xna.Framework;
using SnakeClone.Rendering;
using SnakeClone.Actors;
using System.Diagnostics;
using System.Linq;
using System;

namespace SnakeClone.Providers
{
    internal class HardCodedLevelProvider : ILevelProvider
    {
        private readonly SnakePiece head;
        private readonly Spawner<SnakePiece> tailSpawner;
        private readonly IElementSpawner elementSpawner;
        private ITile[,] grid;

        public HardCodedLevelProvider()
        {
            ParseMap();
            elementSpawner = new RandomFoodFactory(5.0d);

            tailSpawner = new Spawner<SnakePiece>(position =>
                        new SnakePiece(
                            new Transform(
                            () => new Color(26, 188, 156),
                            () => "snakeBody",
                            () => Vector2.One,
                            () => position,
                            () => 0.0f,
                            () => 0.0f)));

            head = new SnakePiece(new Transform(
                            () => new Color(26, 188, 156),
                            () => "snakeHead",
                            () => Vector2.One,
                            () => new Vector2(LevelSettings.SnakeInitialPosition.X, LevelSettings.SnakeInitialPosition.Y),
                            () => 0.0f,
                            () => 0.0f));
        }

        public LevelSettings LevelSettings
        { get; private set; }

        public IElementSpawner ElementSpawner { get { return elementSpawner; } }

        private void ParseMap()
        {
            string[] map;
            try
            {
                map = System.IO.File.ReadAllLines(@"Content/Settings/1_grid.txt");
            }
            catch (System.Exception ex)
            {
                Debug.Write(ex.Message);
                GenerateHardcodedGrid();
                return;
            }

            Point playerLocation = Point.Zero;
            if (map.Length != 20)
            {
                GenerateHardcodedGrid();
                return;
            }
            grid = new ITile[20, 20];
            for (int x = 0; x < map.Length; x++)
            {
                var tiles = map[x].Split('|').Where(str => str != string.Empty).ToArray();
                if (tiles.Length != 20)
                {
                    GenerateHardcodedGrid();
                    return;
                }
                for (int y = 0; y < tiles.Length; y++)
                {
                    var location = new Vector2(y, x);
                    if (tiles[y] == "_")
                    {
                        grid[y,x] = new CommonTile(new Transform(
                                    () => new Color(44, 62, 80),
                                    () => AssetReference.WhitePixel,
                                    () => Vector2.One,
                                    () => location,
                                    () => 0.0f,
                                    () => 0.0f));
                    }
                    else if (tiles[y] == "X")
                    {
                        grid[y, x] = new DeathTile(new Transform(
                               () => new Color(189, 195, 199),
                               () => AssetReference.WhitePixel,
                               () => Vector2.One,
                               () => location,
                               () => 0.0f,
                               () => 0.0f));
                    }
                    else if (tiles[y] == "O")
                    {
                        playerLocation = new Point(y, x);
                        grid[y, x] = new CommonTile(new Transform(
                                     () => new Color(44, 62, 80),
                                     () => AssetReference.WhitePixel,
                                     () => Vector2.One,
                                     () => location,
                                     () => 0.0f,
                                     () => 0.0f));
                    }
                    else
                    {
                        GenerateHardcodedGrid();
                        return;
                    }
                }
            }
            LevelSettings = new LevelSettings(20, 20, playerLocation, 0.11d, 3);
        }

        private void GenerateHardcodedGrid()
        {
            LevelSettings = new LevelSettings(20, 20, new Point(10, 3), 0.11d, 3);
            grid = new ITile[LevelSettings.HorizontalTileCount, LevelSettings.VerticalTileCount];

            for (int x = 0; x < LevelSettings.HorizontalTileCount; x++)
            {
                for (int y = 0; y < LevelSettings.VerticalTileCount; y++)
                {
                    var location = new Vector2(x, y);

                    if ((x == 9 && y == 9)
                    || (x == 8 && y == 9)
                    || (x == 9 && y == 8)
                    || (x == 9 && y == 10)
                    || (x == 10 && y == 9))
                    {
                        grid[x, y] = new DeathTile(new Transform(
                       () => new Color(189, 195, 199),
                       () => AssetReference.WhitePixel,
                       () => Vector2.One,
                       () => location,
                       () => 0.0f,
                       () => 0.0f));
                    }
                    else
                    {
                        grid[x, y] = new CommonTile(new Transform(
                            () => new Color(44, 62, 80),
                            () => AssetReference.WhitePixel,
                            () => Vector2.One,
                            () => location,
                            () => 0.0f,
                            () => 0.0f));
                    }
                }
            }
        }

        public ITile[,] Grid
        {
            get
            {
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
