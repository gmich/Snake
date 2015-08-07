using Microsoft.Xna.Framework;


namespace SnakeClone
{
    internal class RenderedMessage
    {
        private readonly string message;
        private readonly Color color;

        public RenderedMessage(string message,Color color)
        {
            this.message = message;
            this.color = color;
        }

        public string Message {  get { return message; } }

        public Color Color {  get { return color; } }

    }
}
