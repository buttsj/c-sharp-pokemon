using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoGame
{
    class EncounterGameState : IGameState
    {
        Game1 game;
        public UniversalGUI menu;

        private bool faderStart = false;
        private bool fadeIn = true;
        private Texture2D faderTexture;
        private float faderAlpha;
        private float faderAlphaIncrement = 15;
        private float counter = 100;
        private SpriteFont font;

        Monster randomMon;

        public EncounterGameState(Game1 game)
        {
            font = Game1.gameContent.Load<SpriteFont>("Fonts/guiFont");
            this.game = game;
            game.background = Color.White; 
            menu = new UniversalGUI(game);
            menu.columnOne.Add(new KeyValuePair<ICommands, string>(new FightMenuCommand(this, game), "FIGHT"));
            menu.columnOne.Add(new KeyValuePair<ICommands, string>(new MonsterMenuCommand(game), "MONSTERS"));
            menu.columnTwo.Add(new KeyValuePair<ICommands, string>(new BagMenuCommand(), "BAG"));
            menu.columnTwo.Add(new KeyValuePair<ICommands, string>(new RunAwayCommand(game), "RUN"));

            menu.defaultOne.Add(new KeyValuePair<ICommands, string>(new FightMenuCommand(this, game), "FIGHT"));
            menu.defaultOne.Add(new KeyValuePair<ICommands, string>(new MonsterMenuCommand(game), "MONSTERS"));
            menu.defaultTwo.Add(new KeyValuePair<ICommands, string>(new BagMenuCommand(), "BAG"));
            menu.defaultTwo.Add(new KeyValuePair<ICommands, string>(new RunAwayCommand(game), "RUN"));

            menu.currentCommand = menu.columnOne[0].Key;

            menu.Column1StartingPosition = new Vector2(550, 350);
            menu.Column2StartingPosition = new Vector2(650, 350);
            menu.arrowStartingPosition = new Vector2(540, 350);
            menu.CameraPointer = new Vector2(530, 270);

            game.keyboard = new EncounterController(menu);

            menu.graphicHolder.Add(new KeyValuePair<Texture2D, Rectangle>(Game1.gameContent.Load<Texture2D>("GUI Sprites/encounterWindow"), new Rectangle(330, 342, 400, 47)));
            menu.graphicHolder.Add(new KeyValuePair<Texture2D, Rectangle>(Game1.gameContent.Load<Texture2D>("GUI Sprites/encounterSelectWindow"), new Rectangle(530, 342, 200, 47)));

            faderTexture = new Texture2D(game.GraphicsDevice, 1, 1);
            var colors = new Color[] { Color.White };
            faderTexture.SetData<Color>(colors);
            faderStart = true;
        }

        public void Update(GameTime gameTime)
        {
            game.keyboard.Update();
            menu.Update(gameTime);
            game.camera.LookAt(menu.CameraPointer);
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!faderStart)
            {
                menu.Draw(spriteBatch);
                spriteBatch.Draw(game.level.player.pocketMonsters[0].sprite, new Rectangle(345, 300, 43, 38), Color.White);
                spriteBatch.DrawString(font, "Level: " + game.level.player.pocketMonsters[0].level.ToString(), new Vector2(390, 300), Color.Black);
                spriteBatch.DrawString(font, game.level.player.pocketMonsters[0].name, new Vector2(390, 320), Color.Black);
                spriteBatch.DrawString(font, game.level.player.pocketMonsters[0].currHealth.ToString() + "/" + game.level.player.pocketMonsters[0].MaxHP, new Vector2(350, 280), Color.Black);
            }
            
            if (faderStart)
            {
                spriteBatch.Draw(faderTexture, game.GraphicsDevice.Viewport.Bounds, new Color(Color.Black, (byte)MathHelper.Clamp(faderAlpha, 0, 255)));
                if (fadeIn)
                {
                    faderAlpha += faderAlphaIncrement;
                    if (faderAlpha >= 255)
                    {
                        fadeIn = false;
                    }
                }
                else 
                {
                    faderAlpha -= faderAlphaIncrement;
                    if (faderAlpha <= 0)
                    {
                        fadeIn = true;
                    }
                }
                counter--;
            }
            if (counter <= 0)
            {
                faderStart = false;
            }
        }
    }
}
