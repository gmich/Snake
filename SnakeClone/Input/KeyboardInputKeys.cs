using Microsoft.Xna.Framework.Input;

namespace SnakeClone.Input
{
    public class KeyboardInputKeys
    {
        public KeyboardInputKeys()
        {
            Right = Keys.Right;
            Left = Keys.Left;
            Up = Keys.Up;
            Down = Keys.Down;
        }

        public Keys Right { get; set; }

        public Keys Left { get; set; }

        public Keys Up { get; set; }

        public Keys Down { get; set; }

    }


}
