using Microsoft.Xna.Framework.Graphics;
using System;

namespace SnakeClone.Rendering
{
    internal class StaticTexture: ITexture
    {
        private readonly Func<Texture2D> textureGetter;
        public StaticTexture(Func<Texture2D> textureGetter)
        {
            this.textureGetter = textureGetter;
        }
        public Texture2D GetTexture()
        {
            return textureGetter();
        }

    }
}
