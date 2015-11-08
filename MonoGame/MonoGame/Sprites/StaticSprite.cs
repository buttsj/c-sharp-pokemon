using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MonoGame
{
    class StaticSprite : IAnimatedSprite
    {
        Texture2D Texture { get; set; }
        int Rows { get; set; }
        int Columns { get; set; }

        public StaticSprite(Texture2D texture)
        {
            Texture = texture;
            Rows = 1;
            Columns = 1;
        }

        public Rectangle GetBoundingBox(Vector2 position)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            return new Rectangle((int)position.X, (int)position.Y, width, height);
        }

        public void Update(GameTime gameTime) { }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            spriteBatch.Draw(Texture, location, color);
        }
    }
}
