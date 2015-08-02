using Microsoft.Xna.Framework;
using System;

namespace SnakeClone.Providers
{
    internal class AssetReference
    {
        private readonly Color color;
        private readonly string reference;
        private readonly Type type;

        public AssetReference(Type type, Color color, string reference)
        {
            this.type = type;
            this.color = color;
            this.reference = reference;
        }

        public Color Color {  get { return color; } }

        public Type Type {  get { return type; } }

        public string Reference {  get { return reference; } }
    }
}
