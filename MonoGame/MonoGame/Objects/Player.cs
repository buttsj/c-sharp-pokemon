using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Collections.Generic;

namespace MonoGame
{
    public class Player
    {
        private enum availState { up, down, left, right }
        private Player.availState curState;

        public IPlayerState state { get; set; }
        public Vector2 position;
        public Vector2 oldPosition;
        
        public List<Monster> pocketMonsters = new List<Monster>();
        public int monsterCount = 0;
        public ArrayList storedMonsters = new ArrayList();
        public MonsterBuilder monsterBuilder;

        public bool displayMonsters = false;
        public bool interactable = false;

        public Enemy interactEnemy;

        public Player(Vector2 startingPosition)
        {
            curState = availState.right;
            state = new RightIdleState(this);
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
            curState = availState.down;
            state.Down();
            position.Y += 1;
    }

        public void Left()
        {
            curState = availState.left;
            state.Left();
            position.X -= 1;
        }

        public void Right()
        {
            curState = availState.right;
            state.Right();
            position.X += 1;
        }

        public void Up()
        {
            curState = availState.up;
            state.Up();
            position.Y -= 1;
        }

        public void Interact()
        {
            if (interactable)
            {
                //interactEnemy.talkedTo = true;
                interactable = false;
                if (curState == availState.up)
                {
                    interactEnemy.state.Down();
                }
                else if (curState == availState.down)
                {
                    interactEnemy.state.Up();
                }
                else if (curState == availState.left)
                {
                    interactEnemy.state.Right();
                }
                else
                {
                    interactEnemy.state.Left();
                }
            }
            else
            {
                interactable = false;
                interactEnemy = null;
            }
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
