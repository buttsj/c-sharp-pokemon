using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    class EncounterGameState : IGameState 
    {
        Game1 game;

        public EncounterGameState(Game1 game)
        {
            this.game = game;
            game.keyboard = new KeyboardController(game.level.player, game);
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
