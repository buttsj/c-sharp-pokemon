using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoGame
{
    class NullCommand : ICommands
    {
        Player player;
        
        public NullCommand()
        {
        }
        public void Execute()
        {
        }
    }
}
