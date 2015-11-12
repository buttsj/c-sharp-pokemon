using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    public interface IAnimatedSprite
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location, Color color);
        Rectangle GetBoundingBox(Vector2 position);

    }
}
