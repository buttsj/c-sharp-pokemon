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
        private int initialDelay = 10;
        private bool doInitDelay = true;

        public KeyboardController(Player currentPlayer, Game1 game)
        {
            player = currentPlayer;
            commandLibrary = new Dictionary<Keys, ICommands>();
            commandLibrary.Add(Keys.W, currentCommand = new UpCommand(player));
            commandLibrary.Add(Keys.A, currentCommand = new LeftCommand(player));
            commandLibrary.Add(Keys.S, currentCommand = new DownCommand(player));
            commandLibrary.Add(Keys.D, currentCommand = new RightCommand(player));
            commandLibrary.Add(Keys.Enter, currentCommand = new PauseCommand(game));
        }

        public void Update()
        {
            if (doInitDelay)
            {
                initialDelay--;
            }
            if (initialDelay <= 0)
            {
                doInitDelay = false;
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
}
