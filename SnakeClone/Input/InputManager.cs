using System;
using Microsoft.Xna.Framework;

namespace SnakeClone.Input
{
    public class InputManager : GameComponent
    {

        #region Ctors

        public InputManager(Game game)
            : base(game)
        { }

        static InputManager()
        {
            InputKeys = new KeyboardInputKeys();
        }

        #endregion


        public static KeyboardInputKeys InputKeys { get; private set; }

        private static Lazy<KeyboardInput> keyboard = new Lazy<KeyboardInput>();
        public static KeyboardInput Keyboard
        {
            get
            {
                return keyboard.Value;
            }
        }

        #region Update

        public override void Update(GameTime gameTime)
        {
            Flush(Keyboard);
        }

        private static void Flush(IInput input)
        {
            input?.Flush();
        }

        #endregion

    }
}
