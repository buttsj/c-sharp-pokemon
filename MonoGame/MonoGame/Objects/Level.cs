using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    public class Level
    {
        Game1 game;
        public Player player;
        public LevelBuilder builder;
       
        public Level(string fileName)
        {
            game = Game1.GetInstance();
            builder = new LevelBuilder(this);
            player = builder.Build(fileName);
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
        }
    }
}
