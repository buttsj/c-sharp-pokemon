using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Collections.Generic;

namespace MonoGame
{
    public class Enemy
    {

        public IPlayerState state { get; set; }
        public Vector2 position;
        public Vector2 oldPosition;
        
        public List<Monster> pocketMonsters = new List<Monster>();
        public int monsterCount = 0;
        public MonsterBuilder monsterBuilder;

        public bool displayMonsters = false;

        public Enemy(Vector2 startingPosition)
        {
            state = new ERightIdleState(this);
            position = startingPosition;
            oldPosition = startingPosition;
            monsterBuilder = new MonsterBuilder("Index/Index.csv");
            CreateAMonster();
        }

        public void CreateAMonster()
        {
            pocketMonsters.Add(monsterBuilder.monsterList["Jigglypuff"]);
            monsterCount++;
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
