using Microsoft.Xna.Framework;
using System;

namespace SnakeClone
{
    internal class RenderedMessage
    {
        private readonly Func<string> message;
        private readonly Color color;

        public RenderedMessage(Func<string> message,Color color)
        {
            this.message = message;
            this.color = color;
        }

        public string Message {  get { return message(); } }

        public Color Color {  get { return color; } }

    }
}
