using Microsoft.Xna.Framework;
using SnakeClone.Actors;

namespace SnakeClone.Map
{
    internal class LevelSettings
    {
        private readonly Point snakeInitialPosition;
        private readonly int horizontalTileCount;
        private readonly int verticalTileCount;
        private readonly int maxLives;

        public LevelSettings(int horizontalTileCount, 
                             int verticalTileCount,
                             Point snakeInitialPosition,
                             double snakeSpeed,
                             int maxLives)
        {
            this.maxLives = maxLives;
            this.snakeInitialPosition = snakeInitialPosition;
            this.horizontalTileCount = horizontalTileCount;
            this.verticalTileCount = verticalTileCount;
            SnakeSpeed = snakeSpeed;
        }

        public int MaxLives {  get { return maxLives; } }

        public Point SnakeInitialPosition { get { return snakeInitialPosition; } }

        public int HorizontalTileCount {  get { return horizontalTileCount; } }

        public int VerticalTileCount { get { return verticalTileCount; } }

        public double SnakeSpeed { get; set; }
    }
}
