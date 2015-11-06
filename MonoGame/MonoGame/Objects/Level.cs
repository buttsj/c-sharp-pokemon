using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    public class Level
    {
        Game1 game;
        public Player player;
       
        public Level(string fileName)
        {
            game = Game1.GetInstance();
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
