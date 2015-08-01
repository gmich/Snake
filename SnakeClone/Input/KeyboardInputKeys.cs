using Microsoft.Xna.Framework.Input;

namespace SnakeClone.Input
{
    public class KeyboardInputKeys
    {
        public KeyboardInputKeys()
        {
            Right = Keys.D;
            Left = Keys.A;
            Up = Keys.W;
            Down = Keys.S;
        }

        public Keys Right { get; set; }

        public Keys Left { get; set; }

        public Keys Up { get; set; }

        public Keys Down { get; set; }

    }


}
