using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoGame
{
    class GUI
    {
        Game1 game;

        public List<KeyValuePair<ICommands, string>> options { get; set; }
        public ICommands currentCommand { get; set; }
        int selection = 0, menuNumber = 0;
        SpriteFont font;
        Vector2 adjust = new Vector2(0, 15);
        SpriteFactory factory;

        int buffer = 0;
        int inputBuffer = 10;

        IAnimatedSprite arrow;

        public Vector2 textStartingPosition = new Vector2(550, 50);
        public Vector2 arrowStartingPosition = new Vector2(540, 50);
        
        public GUI(Game1 game)
        {
            this.game = game;
            options = new List<KeyValuePair<ICommands, string>>();
            font = Game1.gameContent.Load<SpriteFont>("Fonts/guiFont");
            factory = new SpriteFactory();
            arrow = factory.builder(SpriteFactory.sprites.arrow);
        }

        public void Down()
        {
            if (buffer >= inputBuffer)
            {
                buffer = 0;
                selection++;
                if (selection >= options.Count)
                {
                    selection = 0;
                }
                currentCommand = options[selection].Key;
            }
        }
        public void Up()
        {
            if (buffer >= inputBuffer)
            {
                buffer = 0;
                selection--;
                if (selection < 0)
                {
                    selection = options.Count - 1;
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
        }

        public void Update(GameTime gameTime)
        {
            buffer++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (KeyValuePair<ICommands, string> pair in options)
            {
                spriteBatch.DrawString(font, pair.Value, textStartingPosition + (adjust * menuNumber), Color.Black);
                menuNumber++;
            }
            arrow.Draw(spriteBatch, arrowStartingPosition + (adjust * selection), Color.White);
            menuNumber = 0;
        }

    }
}
