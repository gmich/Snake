﻿using Microsoft.Xna.Framework.Input;

namespace SnakeClone.Input
{
    public class KeyboardInput : IInput
    {

        #region Fields

        private KeyboardState keyboardState = Keyboard.GetState();
        private KeyboardState previousKeyboardState;

        #endregion

        #region Keyboard

        public Keys[] GetPressedKeys()
        {
            return keyboardState.GetPressedKeys();
        }

        public bool IsKeyPressed(Keys keyToTest)
        {
            return keyboardState.IsKeyDown(keyToTest);
        }

        public bool IsKeyReleased(Keys keyToTest)
        {
            return (keyboardState.IsKeyUp(keyToTest)
                   && previousKeyboardState.IsKeyDown(keyToTest));
        }

        public bool IsKeyClicked(Keys keyToTest)
        {
            return (keyboardState.IsKeyDown(keyToTest)
                   && previousKeyboardState.IsKeyUp(keyToTest));
        }
        
        #endregion

        #region Update

        public void Flush()
        {
            previousKeyboardState = keyboardState;            
            keyboardState = Keyboard.GetState();
        }


        #endregion
        
    }
}