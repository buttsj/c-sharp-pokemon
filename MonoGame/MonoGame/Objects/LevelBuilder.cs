using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoGame
{
    public class LevelBuilder
    {
        Player player;
        Level level;
        int spacingIncrement = 16;

        public LevelBuilder(Level currentLevel)
        {
            this.level = currentLevel;
        }

        public Player Build(string fileName)
        {
            player = new Player(new Microsoft.Xna.Framework.Vector2(0, 0));
            return player;
        }
    }
}
