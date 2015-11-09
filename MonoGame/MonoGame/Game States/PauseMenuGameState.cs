using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoGame
{
    class PauseMenuGameState : IGameState 
    {
        int inputBuffer = 10;
        Game1 game;
        SpriteFactory factory;
        public GUI menu;
        

        public PauseMenuGameState(Game1 game)
        {
            factory = new SpriteFactory();
            this.game = game;

            menu = new GUI(game);
            menu.options.Add(new KeyValuePair<ICommands, string>(new IndexMenuCommand(), "Monster Index"));
            menu.options.Add(new KeyValuePair<ICommands, string>(new MonsterMenuCommand(), "Monsters"));
            menu.options.Add(new KeyValuePair<ICommands, string>(new BagMenuCommand(), "Bag"));
            menu.options.Add(new KeyValuePair<ICommands, string>(new GearMenuCommand(), "Gear"));
            menu.options.Add(new KeyValuePair<ICommands, string>(new CharacterMenuCommand(), "Character"));
            menu.options.Add(new KeyValuePair<ICommands, string>(new SaveMenuCommand(), "Save"));
            menu.options.Add(new KeyValuePair<ICommands, string>(new OptionsMenuCommand(), "Options"));
            menu.options.Add(new KeyValuePair<ICommands, string>(new ExitMenuCommand(game), "Exit"));
            menu.currentCommand = menu.options[0].Key;

            game.keyboard = new MenuController(menu);
        }

        public void Update(GameTime gameTime)
        {
            game.keyboard.Update();
            menu.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
            menu.Draw(spriteBatch);
        }
    }
}
