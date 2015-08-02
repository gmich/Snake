using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeClone.Rendering
{
    internal class LevelRenderInfo
    {
        private readonly int tileWidth;
        private readonly int tileHeight;
        private readonly float scale;

        public LevelRenderInfo(int tileWidth, int tileHeight, float scale)
        {
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.scale = scale;
        }

        public float Scale {  get { return scale; } }
        public int TileWidth { get { return tileWidth; } }
        public int TileHeight { get { return tileHeight; } }
    }
}
