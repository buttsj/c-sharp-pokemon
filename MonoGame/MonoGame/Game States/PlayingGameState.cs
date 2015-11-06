using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    class PlayingGameState : IGameState 
    {
        Game1 game;

        public PlayingGameState()
        {
            game = Game1.GetInstance();
            game.keyboard = new KeyboardController(game.level.player);
        }

        public void Update(GameTime gameTime)
        {
            game.keyboard.Update();
            game.level.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
