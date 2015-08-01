namespace SnakeClone.Map
{
    internal class BlankMapGenerator : IMapGenerator
    {
        private readonly int horizontalTileCount;
        private readonly int verticalTileCount;

        public BlankMapGenerator(int horizontalTileCount,int verticalTileCount)
        {
            this.horizontalTileCount = horizontalTileCount;
            this.verticalTileCount = verticalTileCount;
        }

        public ITile[,] Generate()
        {
            ITile[,] grid = new ITile[horizontalTileCount, verticalTileCount];

            for(int x=0;x< horizontalTileCount; x++)
            {
                for (int y = 0; y < verticalTileCount; y++)
                    grid[x, y] = new BlankTile();
            }
            return grid;
        }
    }
}
