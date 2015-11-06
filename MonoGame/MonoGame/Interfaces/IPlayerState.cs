using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    public interface IPlayerState
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location, Color color);
        void Up();
        void Down();
        void Left();
        void Right();

    }
}
