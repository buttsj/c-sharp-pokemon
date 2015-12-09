using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    public class Monster
    {
        public int level;

        public int hp;
        public int atk;
        public int def;
        public int spAtk;
        public int spDef;
        public int speed;

        public int MaxHP;
        public int MaxATK;
        public int MaxDEF;
        public int MaxSPATK;
        public int MaxSPDEF;
        public int MaxSPEED;

        public int currHealth;
        public int currAtk;
        public int currDef;
        public int currSPATK;
        public int currSPDEF;
        public int currSpeed;

        public string name;

        public string[] moves;
        
        public Texture2D sprite;

        public Monster(string name, int hp, int atk, int def, int spAtk, int spDef, int speed, string location)
        {
            level = 10;
            this.name = name;
            this.hp = hp;
            this.atk = atk;
            this.def = def;
            this.spAtk = spAtk;
            this.spDef = spDef;
            this.speed = speed;
            
            sprite = Game1.gameContent.Load<Texture2D>(location);
            moves = new string[4];
            moves[0] = "Tackle";
            moves[1] = "Sleep";
            moves[2] = "Hit";
            moves[3] = "Wombo";

            CalculateMaxes();
        }

        public void CalculateMaxes()
        {
            MaxHP = (((hp * 2) * level) / 100) + level + 10;
            MaxATK = (((atk * 2) * level) / 100) + 5;
            MaxDEF = (((def * 2) * level) / 100) + 5;
            MaxSPATK = (((spAtk * 2) * level) / 100) + 5;
            MaxSPDEF = (((spDef * 2) * level) / 100) + 5;
            MaxSPEED = (((speed * 2) * level) / 100) + 5;

            currHealth = MaxHP;
        }

        public void ResetStats()
        {
            currHealth = MaxHP;
            currAtk = MaxATK;
            currDef = MaxDEF;
            currSPATK = MaxSPATK;
            currSPDEF = MaxSPDEF;
            currSpeed = MaxSPEED;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Rectangle(480, 300, 40, 40), Color.White);
        }
        
    }
}
