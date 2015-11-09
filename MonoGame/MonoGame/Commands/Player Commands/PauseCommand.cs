using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoGame
{
    class PauseCommand : ICommands
    {
        Game1 game;
        
        public PauseCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.gameState = new PauseMenuGameState(game);
        }
    }
}
