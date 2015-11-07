using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    class TreeTileState : ITileState
    {
        Game1 game;
        IAnimatedSprite sprite;

        public TreeTileState(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.builder(SpriteFactory.sprites.treeTile);
            this.game = game;
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
