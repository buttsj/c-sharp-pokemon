using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;

namespace MonoGame
{
    public class Player
    {

        public IPlayerState state { get; set; }
        public Vector2 position;
        public Vector2 oldPosition;

        public Monster createdMonster;
        public Monster[] pocketMonsters = new Monster[8];
        public int monsterCount = 0;
        public ArrayList storedMonsters = new ArrayList();
        public MonsterBuilder monsterBuilder;

        public Player(Vector2 startingPosition)
        {
            state = new RightIdleState(this);
            position = startingPosition;
            oldPosition = startingPosition;
            monsterBuilder = new MonsterBuilder("Index/Index.csv");
            CreateAMonster();
        }

        public void CreateAMonster()
        {
            createdMonster = monsterBuilder.monsterList["Jigglypuff"];
            AcquireMonster(createdMonster);
        }

        public void Idle()
        {
            state.Idle();
        }

        public void Down()
        {
            state.Down();
            position.Y += 1;
    }

        public void Left()
        {
            state.Left();
            position.X -= 1;
        }

        public void Right()
        {
            state.Right();
            position.X += 1;
        }

        public void Up()
        {
            state.Up();
            position.Y -= 1;
        }

        public void AcquireMonster(Monster mon)
        {
            pocketMonsters[monsterCount] = mon;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch, position, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            state.Update(gameTime);
        }
    }
}
