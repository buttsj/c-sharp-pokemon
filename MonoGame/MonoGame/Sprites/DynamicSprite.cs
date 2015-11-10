using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MonoGame
{
    class DynamicSprite : IAnimatedSprite
    {
        Texture2D Texture { get; set; }
        int Rows { get; set; }
        int Columns { get; set; }
        int currentFrame;
        int totalFrames;
        int animTimer;
        int UpdateSpeed { get; set; }
        
        public DynamicSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            UpdateSpeed = 150;
        }

        public Rectangle GetBoundingBox(Vector2 position)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
            return new Rectangle((int)position.X, (int)position.Y, width, height);
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
