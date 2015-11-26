using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoGame
{
    class EncounterGameState : IGameState 
    {
        Game1 game;
        public UniversalGUI menu;

        public EncounterGameState(Game1 game)
        {
            this.game = game;
            menu = new UniversalGUI(game);
            menu.columnOne.Add(new KeyValuePair<ICommands, string>(new FightMenuCommand(), "FIGHT"));
            menu.columnOne.Add(new KeyValuePair<ICommands, string>(new MonsterMenuCommand(game), "MONSTERS"));
            menu.columnTwo.Add(new KeyValuePair<ICommands, string>(new BagMenuCommand(), "BAG"));
            menu.columnTwo.Add(new KeyValuePair<ICommands, string>(new RunAwayCommand(game), "RUN"));
            menu.currentCommand = menu.columnOne[0].Key;

            menu.Column1StartingPosition = new Vector2(550, 350);
            menu.Column2StartingPosition = new Vector2(650, 350);
            menu.arrowStartingPosition = new Vector2(540, 350);
            menu.CameraPointer = new Vector2(530, 270);

            game.keyboard = new EncounterController(menu);

            menu.graphicHolder.Add(new KeyValuePair<Texture2D, Rectangle>(Game1.gameContent.Load<Texture2D>("GUI Sprites/encounterWindow"), new Rectangle(330, 342, 400, 47)));
            menu.graphicHolder.Add(new KeyValuePair<Texture2D, Rectangle>(Game1.gameContent.Load<Texture2D>("GUI Sprites/encounterSelectWindow"), new Rectangle(530, 342, 200, 47)));
        }

        public void Update(GameTime gameTime)
        {
            game.keyboard.Update();
            menu.Update(gameTime);
            game.camera.LookAt(menu.CameraPointer);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            menu.Draw(spriteBatch);
        }
    }
}
