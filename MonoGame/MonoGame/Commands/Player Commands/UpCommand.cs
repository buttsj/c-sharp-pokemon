using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoGame
{
    class UpCommand : ICommands
    {
        Player player;
        
        public UpCommand(Player currentPlayer)
        {
            player = currentPlayer;
        }
        public void Execute()
        {
            player.Up();
        }
    }
}
