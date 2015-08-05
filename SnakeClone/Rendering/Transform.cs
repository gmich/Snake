using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnakeClone.Rendering
{
    internal class Transform
    {

        public Transform(Func<Color> color,
                         Func<string> textureReference,
                         Func<Vector2> scale,
                         Func<Vector2> location,
                         Func<float> rotation,
                         Func<float> layer)
        {
            this.color = color;
            this.textureReference = textureReference;
            this.scale = scale;
            this.location = location;
            this.rotation = rotation;
            this.layer = layer;
        }

        private readonly Func<Color> color;
        private readonly Func<string> textureReference;
        private readonly Func<Vector2> scale;
        private readonly Func<Vector2> location;
        private readonly Func<float> rotation;
        private readonly Func<float> layer;

        public Color Color { get { return color(); } }
        public string TextureReference { get { return textureReference(); } }
        public Vector2 Scale { get { return scale(); } }
        public Vector2 Location { get { return location(); } }
        public float Rotation { get { return rotation(); } }
        public float Layer {  get { return layer(); } }
    }
}
