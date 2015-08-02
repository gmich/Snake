using Microsoft.Xna.Framework.Graphics;
using System;

namespace SnakeClone.Rendering
{
    internal class StaticTexture: ITexture
    {
        private readonly Texture2D texture;
        public StaticTexture(Texture2D texture)
        {
            this.texture = texture;
        }
        public Texture2D GetTexture()
        {
            return texture;
        }

    }
}
