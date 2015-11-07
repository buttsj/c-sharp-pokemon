using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    public class Player
    {

        public IPlayerState state { get; set; }
        public Vector2 position;
        public bool isLeft = false;
        public bool isRight = false;
        public bool isUp = false;
        public bool isDown = false;

        public Player(Vector2 startingPosition)
        {
            state = new RightIdleState(this);
            position = startingPosition;
            isDown = true;
        }

        public void Idle()
        {
            state.Idle();
        }

        public void Down()
        {
            isDown = true;
            isLeft = false;
            isRight = false;
            isUp = false;
            state.Down();
            position.Y += 1;
    }

        public void Left()
        {
            isDown = false;
            isLeft = true;
            isRight = false;
            isUp = false;
            state.Left();
            position.X -= 1;
        }

        public void Right()
        {
            isDown = false;
            isLeft = false;
            isRight = true;
            isUp = false;
            state.Right();
            position.X += 1;
        }

        public void Up()
        {
            isDown = false;
            isLeft = false;
            isRight = false;
            isUp = true;
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
