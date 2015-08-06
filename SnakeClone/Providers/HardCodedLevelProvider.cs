﻿using SnakeClone.Map;
using Microsoft.Xna.Framework;
using SnakeClone.Rendering;
using SnakeClone.Actors;

namespace SnakeClone.Providers
{
    internal class HardCodedLevelProvider : ILevelProvider
    {
        private readonly SnakePiece head;
        private readonly Spawner<SnakePiece> tailSpawner;
        private readonly IElementSpawner elementSpawner;

        public HardCodedLevelProvider()
        {
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
        { get; } = new LevelSettings(20, 20, new Point(5, 5), 0.1d, 3);

        public IElementSpawner ElementSpawner { get { return elementSpawner; } }

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
                            () => new Color(44, 62, 80),
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
