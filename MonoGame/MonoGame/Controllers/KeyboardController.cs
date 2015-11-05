using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    class KeyboardController : IController
    {
        private KeyboardState keyboardState;
        private ICommands currentCommand;
        private Dictionary<Keys, ICommands> commandLibrary;

        public KeyboardController()
        {

        }

        public void Update()
        {
            foreach (Keys key in keyboardState.GetPressedKeys())
            {

            }
        }
    }
}
