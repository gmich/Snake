using System;
using Microsoft.Xna.Framework;

namespace SnakeClone.Rendering
{
    internal class Transform
    {

        public Transform(Func<Color> color,
                         Func<ITexture> texture,
                         Func<Vector2> scale,
                         Func<Vector2> location,
                         Func<Rectangle> frame,
                         Func<float> rotation)
        {
            this.color = color;
            this.texture = texture;
            this.scale = scale;
            this.location = location;
            this.rotation = rotation;
            this.frame = frame;
        }

        private readonly Func<Color> color;
        private readonly Func<ITexture> texture;
        private readonly Func<Vector2> scale;
        private readonly Func<Vector2> location;
        private readonly Func<float> rotation;
        private readonly Func<Rectangle> frame;

        public Rectangle Frame { get { return frame(); } }
        public Color Color { get { return color(); } }
        public ITexture Texture { get { return texture(); } }
        public Vector2 Scale { get { return scale(); } }
        public Vector2 Location { get { return location(); } }
        private float Rotation { get { return rotation(); } }
    }
}
