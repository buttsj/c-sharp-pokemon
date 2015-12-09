using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoGame
{
    class PauseMenuGameState : IGameState 
    {
        Game1 game;
        public UniversalGUI menu;
        

        public PauseMenuGameState(Game1 game)
        {
            this.game = game;
            menu = new UniversalGUI(game);
            menu.columnOne.Add(new KeyValuePair<ICommands, string>(new IndexMenuCommand(), "Monster Index"));
            menu.columnOne.Add(new KeyValuePair<ICommands, string>(new MonsterMenuCommand(game), "Monsters"));
            menu.columnOne.Add(new KeyValuePair<ICommands, string>(new BagMenuCommand(), "Bag"));
            menu.columnOne.Add(new KeyValuePair<ICommands, string>(new GearMenuCommand(), "Gear"));
            menu.columnOne.Add(new KeyValuePair<ICommands, string>(new CharacterMenuCommand(), "Character"));
            menu.columnOne.Add(new KeyValuePair<ICommands, string>(new SaveMenuCommand(), "Save"));
            menu.columnOne.Add(new KeyValuePair<ICommands, string>(new OptionsMenuCommand(), "Options"));
            menu.columnOne.Add(new KeyValuePair<ICommands, string>(new ExitMenuCommand(game), "Exit"));

            menu.defaultOne.Add(new KeyValuePair<ICommands, string>(new IndexMenuCommand(), "Monster Index"));
            menu.defaultOne.Add(new KeyValuePair<ICommands, string>(new MonsterMenuCommand(game), "Monsters"));
            menu.defaultOne.Add(new KeyValuePair<ICommands, string>(new BagMenuCommand(), "Bag"));
            menu.defaultOne.Add(new KeyValuePair<ICommands, string>(new GearMenuCommand(), "Gear"));
            menu.defaultOne.Add(new KeyValuePair<ICommands, string>(new CharacterMenuCommand(), "Character"));
            menu.defaultOne.Add(new KeyValuePair<ICommands, string>(new SaveMenuCommand(), "Save"));
            menu.defaultOne.Add(new KeyValuePair<ICommands, string>(new OptionsMenuCommand(), "Options"));
            menu.defaultOne.Add(new KeyValuePair<ICommands, string>(new ExitMenuCommand(game), "Exit"));
            menu.currentCommand = menu.columnOne[0].Key;

            menu.Column1StartingPosition.X = game.level.player.position.X + 90;
            menu.Column1StartingPosition.Y = game.level.player.position.Y - 110;
            menu.arrowStartingPosition.X = game.level.player.position.X + 80;
            menu.arrowStartingPosition.Y = game.level.player.position.Y - 110;

            game.keyboard = new MenuController(menu);

            menu.graphicHolder.Add(new KeyValuePair<Texture2D, Rectangle>(Game1.gameContent.Load<Texture2D>("GUI Sprites/menuBorder"), new Rectangle((int)game.level.player.position.X + 70, (int)game.level.player.position.Y - 120, 130, 200)));
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
