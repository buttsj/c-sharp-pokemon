using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    public class Player : IPlayerState
    {

        public IPlayerState state { get; set; }
        public Vector2 position { get; set; }
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

        public void Down()
        {
            isDown = true;
            isLeft = false;
            isRight = false;
            isUp = false;
    }

        public void Left()
        {
            isDown = false;
            isLeft = true;
            isRight = false;
            isUp = false;
        }

        public void Right()
        {
            isDown = false;
            isLeft = false;
            isRight = true;
            isUp = false;
        }

        public void Up()
        {
            isDown = false;
            isLeft = false;
            isRight = false;
            isUp = true;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {

        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
