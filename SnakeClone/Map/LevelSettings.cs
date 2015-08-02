using Microsoft.Xna.Framework;

namespace SnakeClone.Map
{
    internal class LevelSettings
    {
        private readonly Point snakeInitialPosition;
        private readonly IFoodFactory foodFactory;
        private readonly int horizontalTileCount;
        private readonly int verticalTileCount;

        public LevelSettings(int horizontalTileCount, int verticalTileCount,IFoodFactory foodFactory, Point snakeInitialPosition, double snakeSpeed)
        {
            this.snakeInitialPosition = snakeInitialPosition;
            this.foodFactory = foodFactory;
            this.horizontalTileCount = horizontalTileCount;
            this.verticalTileCount = verticalTileCount;
            SnakeSpeed = snakeSpeed;
        }

        public Point SnakeInitialPosition { get { return snakeInitialPosition; } }

        public IFoodFactory FoodFactory { get { return foodFactory; } }

        public int HorizontalTileCount {  get { return horizontalTileCount; } }

        public int VerticalTileCount { get { return verticalTileCount; } }

        public double SnakeSpeed { get; set; }
    }
}
