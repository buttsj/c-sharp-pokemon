using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MonoGame
{
    class PlayerMovingSprite : IAnimatedSprite
    {
        Texture2D Texture { get; set; }
        int Rows { get; set; }
        int Columns { get; set; }
        int currentFrame;
        int totalFrames;
        int animTimer;
        int UpdateSpeed { get; set; }

        public PlayerMovingSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            UpdateSpeed = 150;
        }

        public void Update(GameTime gameTime)
        {
            animTimer += gameTime.ElapsedGameTime.Milliseconds;
            if (animTimer > UpdateSpeed)
            {
                animTimer -= UpdateSpeed;

                currentFrame = (currentFrame + 1) % totalFrames;
                if (currentFrame == totalFrames)
                { currentFrame = 0; }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, color);
        }
    }
}
