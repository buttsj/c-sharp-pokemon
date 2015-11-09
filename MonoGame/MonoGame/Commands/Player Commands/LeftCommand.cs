using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoGame
{
    class LeftCommand : ICommands
    {
        Player player;
        
        public LeftCommand(Player currentPlayer)
        {
            player = currentPlayer;
        }
        public void Execute()
        {
            player.Left();
        }
    }
}
