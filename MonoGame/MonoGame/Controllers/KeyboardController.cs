using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    public class KeyboardController : IController
    {
        private Player player;
        private KeyboardState keyboardState;
        private ICommands currentCommand;
        private Dictionary<Keys, ICommands> commandLibrary;

        public KeyboardController(Player currentPlayer)
        {
            player = currentPlayer;
            commandLibrary = new Dictionary<Keys, ICommands>();
            commandLibrary.Add(Keys.W, currentCommand = new UpCommand(player));
            commandLibrary.Add(Keys.A, currentCommand = new LeftCommand(player));
            commandLibrary.Add(Keys.S, currentCommand = new DownCommand(player));
            commandLibrary.Add(Keys.D, currentCommand = new RightCommand(player));
        }

        public void Update()
        {
            currentCommand = new NullCommand();
            keyboardState = Keyboard.GetState();
            foreach (Keys key in keyboardState.GetPressedKeys())
            {
                if (commandLibrary.ContainsKey(key))
                {
                    currentCommand = commandLibrary[key];
                    currentCommand.Execute();
                    break;
                }
            }
            if (keyboardState.GetPressedKeys().Length == 0)
            {
                player.Idle();
            }
        }
    }
}
