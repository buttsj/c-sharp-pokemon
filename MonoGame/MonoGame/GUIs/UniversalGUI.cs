using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoGame
{
    class UniversalGUI
    {
        // SET THESE IN HERE
        Game1 game;
        SpriteFactory factory;
        Vector2 adjust = new Vector2(0, 15);
        SpriteFont font;
        IAnimatedSprite arrow;
        int buffer = 0;
        int inputBuffer = 10;

        // SET THESE IN THE GAMESTATE
        public List<KeyValuePair<Texture2D, Rectangle>> graphicHolder { get; set; }
        public List<KeyValuePair<ICommands, string>> columnOne { get; set; }
        public List<KeyValuePair<ICommands, string>> columnTwo { get; set; }
        public ICommands currentCommand { get; set; }
        int selection = 0, menuNumber = 0;

        // SET THESE IN THE GAMESTATE
        public Vector2 Column1StartingPosition;
        public Vector2 Column2StartingPosition;
        public Vector2 arrowStartingPosition;
        public Vector2 CameraPointer;
        
        public UniversalGUI(Game1 game)
        {
            this.game = game;
            columnOne = new List<KeyValuePair<ICommands, string>>();
            columnTwo = new List<KeyValuePair<ICommands, string>>();
            graphicHolder = new List<KeyValuePair<Texture2D, Rectangle>>();
            font = Game1.gameContent.Load<SpriteFont>("Fonts/guiFont");
            factory = new SpriteFactory();
            arrow = factory.builder(SpriteFactory.sprites.arrow);
        }

        public void Down()
        {
            if (buffer >= inputBuffer)
            {
                buffer = 0;
                if (columnOne[selection].Key == currentCommand)
                {
                    selection++;
                    if (selection >= columnOne.Count)
                    {
                        selection = 0;
                    }
                    currentCommand = columnOne[selection].Key;
                }
                else
                {
                    selection++;
                    if (selection >= columnTwo.Count)
                    {
                        selection = 0;
                    }
                    currentCommand = columnTwo[selection].Key;
                }
            }
        }
        public void Up()
        {
            if (buffer >= inputBuffer)
            {
                buffer = 0;
                if (columnOne[selection].Key == currentCommand)
                {
                    selection--;
                    if (selection < 0)
                    {
                        selection = columnOne.Count - 1;
                    }
                    currentCommand = columnOne[selection].Key;
                }
                else
                {
                    selection--;
                    if (selection < 0)
                    {
                        selection = columnTwo.Count - 1;
                    }
                    currentCommand = columnTwo[selection].Key;
                }
            }
        }

        public void LeftRight()
        {
            if (buffer >= inputBuffer)
            {
                buffer = 0;
                if (columnOne[selection].Key == currentCommand)
                {
                    arrowStartingPosition = new Vector2(640, 350);
                    currentCommand = columnTwo[selection].Key;
                }
                else
                {
                    arrowStartingPosition = new Vector2(540, 350);
                    currentCommand = columnOne[selection].Key;
                }
            }
        }

        public void Select()
        {
            if (buffer >= inputBuffer)
            {
                buffer = 0;
                currentCommand.Execute();
                arrowStartingPosition = new Vector2(540, 350);
                selection = 0;
                currentCommand = columnOne[selection].Key;
            }
        }

        public void Update(GameTime gameTime)
        {
            buffer++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (KeyValuePair<Texture2D, Rectangle> pair in graphicHolder)
            {
                spriteBatch.Draw(pair.Key, pair.Value, Color.White);
            }

            // display column 1
            foreach (KeyValuePair<ICommands, string> pair in columnOne)
            {
                spriteBatch.DrawString(font, pair.Value, Column1StartingPosition + (adjust * menuNumber), Color.Black);
                menuNumber++;
            }
            menuNumber = 0;

            // display column 2
            foreach (KeyValuePair<ICommands, string> pair in columnTwo)
            {
                spriteBatch.DrawString(font, pair.Value, Column2StartingPosition + (adjust * menuNumber), Color.Black);
                menuNumber++;
            }
            menuNumber = 0;

            arrow.Draw(spriteBatch, arrowStartingPosition + (adjust * selection), Color.White);
        }

    }
}
