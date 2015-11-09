using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoGame
{
    class DownCommand : ICommands
    {
        Player player;
        
        public DownCommand(Player currentPlayer)
        {
            player = currentPlayer;
        }
        public void Execute()
        {
            player.Down();
        }
    }
}
