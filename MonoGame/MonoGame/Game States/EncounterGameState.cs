using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    class EncounterGameState : IGameState 
    {
        Game1 game;
        public EncounterGUI menu;

        public EncounterGameState(Game1 game)
        {
            this.game = game;
            menu = new EncounterGUI(game);
            menu.currentCommand = menu.options[0].Key;
            game.keyboard = new EncounterController(menu);
        }

        public void Update(GameTime gameTime)
        {
            game.keyboard.Update();
            menu.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            menu.Draw(spriteBatch);
        }
    }
}
