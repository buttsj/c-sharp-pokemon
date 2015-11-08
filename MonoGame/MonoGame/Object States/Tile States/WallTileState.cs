using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    class WallTileState : ITileState
    {
        Game1 game;
        IAnimatedSprite sprite;

        public WallTileState(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.builder(SpriteFactory.sprites.wallTile);
            this.game = game;
        }

        public Rectangle GetBoundingBox(Vector2 position)
        {
            return sprite.GetBoundingBox(position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            sprite.Draw(spriteBatch, location, color);
        }
    }
}
