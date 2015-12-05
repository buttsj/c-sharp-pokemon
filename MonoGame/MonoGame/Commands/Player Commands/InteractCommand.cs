using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoGame
{
    class InteractCommand : ICommands
    {
        Player player;
        
        public InteractCommand(Player currentPlayer)
        {
            player = currentPlayer;
        }
        public void Execute()
        {
            player.Interact();
        }
    }
}
