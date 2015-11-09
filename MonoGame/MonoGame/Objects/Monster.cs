using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    public class Monster
    {

        public int hp;
        public int atk;
        public int def;
        public int spec;
        public int spAtk;
        public int spDef;
        public int speed;

        public string name;

        public string[] moves;

        public Monster()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //state.Draw(spriteBatch, position, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            //state.Update(gameTime);
        }
    }
}
