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

        public void Update(GameTime gameTime) { }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            spriteBatch.Draw(Texture, location, color);
        }
    }
}
