using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoGame
{
    class RightCommand : ICommands
    {
        Player player;
        
        public RightCommand(Player currentPlayer)
        {
            player = currentPlayer;
        }
        public void Execute()
        {
            player.Right();
        }
    }
}
