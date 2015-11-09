using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoGame
{
    class EncounterGUI
    {
        Game1 game;

        public List<KeyValuePair<ICommands, string>> options { get; set; }
        public ICommands currentCommand { get; set; }
        int selection = 0;
        SpriteFont font;
        SpriteFactory factory;

        int buffer = 0;
        int inputBuffer = 10;

        IAnimatedSprite arrow;

        public Vector2 textStartingPosition = new Vector2(550, 350);
        Vector2 adjustDown = new Vector2(0, 15);
        Vector2 adjustRight = new Vector2(80, 0);
        public Vector2 arrowStartingPosition = new Vector2(540, 350);

        Texture2D encounterBorder;
        Texture2D encounterSelectWindow;
        
        public EncounterGUI(Game1 game)
        {
            this.game = game;
            options = new List<KeyValuePair<ICommands, string>>();
            options.Add(new KeyValuePair<ICommands, string>(new FightMenuCommand(), "FIGHT"));
            options.Add(new KeyValuePair<ICommands, string>(new BagMenuCommand(), "BAG"));
            options.Add(new KeyValuePair<ICommands, string>(new MonsterMenuCommand(), "MONSTERS"));
            options.Add(new KeyValuePair<ICommands, string>(new RunAwayCommand(game), "RUN"));
            font = Game1.gameContent.Load<SpriteFont>("Fonts/guiFont");
            factory = new SpriteFactory();
            arrow = factory.builder(SpriteFactory.sprites.arrow);

            encounterBorder = Game1.gameContent.Load<Texture2D>("GUI Sprites/encounterWindow");
            encounterSelectWindow = Game1.gameContent.Load<Texture2D>("GUI Sprites/encounterSelectWindow");
        }

        public void Left()
        {
            if (buffer >= inputBuffer)
            {
                buffer = 0;
                switch (selection)
                {
                    case 0:
                        selection = 2;
                        break;
                    case 1:
                        selection = 3;
                        break;
                    case 2:
                        selection = 0;
                        break;
                    case 3:
                        selection = 1;
                        break;
                }
                currentCommand = options[selection].Key;
            }
        }

        public void Right()
        {
            if (buffer >= inputBuffer)
            {
                buffer = 0;
                switch (selection)
                {
                    case 0:
                        selection = 2;
                        break;
                    case 1:
                        selection = 3;
                        break;
                    case 2:
                        selection = 0;
                        break;
                    case 3:
                        selection = 1;
                        break;
                }
                currentCommand = options[selection].Key;
            }
        }

        public void Down()
        {
            if (buffer >= inputBuffer)
            {
                buffer = 0;
                switch (selection)
                {
                    case 0:
                        selection = 1;
                        break;
                    case 1:
                        selection = 0;
                        break;
                    case 2:
                        selection = 3;
                        break;
                    case 3:
                        selection = 2;
                        break;
                }
                currentCommand = options[selection].Key;
            }
        }
        public void Up()
        {
            if (buffer >= inputBuffer)
            {
                buffer = 0;
                switch (selection)
                {
                    case 0:
                        selection = 1;
                        break;
                    case 1:
                        selection = 0;
                        break;
                    case 2:
                        selection = 3;
                        break;
                    case 3:
                        selection = 2;
                        break;
                }
                currentCommand = options[selection].Key;
            }
        }

        public void Select()
        {
            if (buffer >= inputBuffer)
            {
                buffer = 0;
                currentCommand.Execute();
            }
            selection = 0;
            currentCommand = options[selection].Key;
        }

        public void Update(GameTime gameTime)
        {
            buffer++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(encounterBorder, new Rectangle(330, 342, 400, 47), Color.White);
            spriteBatch.Draw(encounterSelectWindow, new Rectangle(530, 342, 200, 47), Color.White);

            spriteBatch.DrawString(font, options[0].Value, textStartingPosition, Color.Black);
            spriteBatch.DrawString(font, options[1].Value, textStartingPosition + adjustDown, Color.Black);
            spriteBatch.DrawString(font, options[2].Value, textStartingPosition + adjustRight, Color.Black);
            spriteBatch.DrawString(font, options[3].Value, textStartingPosition + adjustDown + adjustRight, Color.Black);

            switch (selection)
            {
                case 0:
                    arrow.Draw(spriteBatch, arrowStartingPosition, Color.Black);
                    break;
                case 1:
                    arrow.Draw(spriteBatch, arrowStartingPosition + adjustDown, Color.Black);
                    break;
                case 2:
                    arrow.Draw(spriteBatch, arrowStartingPosition + adjustRight, Color.Black);
                    break;
                case 3:
                    arrow.Draw(spriteBatch, arrowStartingPosition + adjustDown + adjustRight, Color.Black);
                    break;
            }
        }

    }
}
