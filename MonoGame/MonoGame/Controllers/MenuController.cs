using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    class MenuController : IController
    {
        private KeyboardState keyboardState;
        private ICommands currentCommand;
        private Dictionary<Keys, ICommands> commandLibrary;

        public MenuController(GUI menu)
        {
            commandLibrary = new Dictionary<Keys, ICommands>();
            commandLibrary.Add(Keys.Up, new MenuUpCommand(menu));
            commandLibrary.Add(Keys.Down, new MenuDownCommand(menu));
            commandLibrary.Add(Keys.Enter, new MenuSelectCommand(menu));
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
        }
    }
}
