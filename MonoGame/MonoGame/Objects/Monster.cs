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
        
        public Texture2D sprite;

        public Monster(string name, int hp, int atk, int def, int spec, int spAtk, int spDef, int speed, string location)
        {
            this.hp = hp;
            this.atk = atk;
            this.def = def;
            this.spec = spec;
            this.spAtk = spAtk;
            this.spDef = spDef;
            this.speed = speed;
            this.name = name;
            
            sprite = Game1.gameContent.Load<Texture2D>(location);
            moves = new string[4];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Rectangle(480, 300, 40, 40), Color.White);
        }
        
    }
}
