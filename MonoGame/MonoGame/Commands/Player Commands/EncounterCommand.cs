using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoGame
{
    class EncounterCommand : ICommands
    {
        Game1 game;
        
        public EncounterCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.gameState = new EncounterGameState(game);
        }
    }
}
