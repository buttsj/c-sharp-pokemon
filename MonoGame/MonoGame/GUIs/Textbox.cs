using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace MonoGame
{
    public class Textbox
    {
        // SET THESE IN HERE
        SpriteFont font;
        int scrollTimer = 5;

        string text = "";
        string currText = "";
        int index = 0;
        bool scrollBool = true;
        public bool complete = false;

        Texture2D textWindow = Game1.gameContent.Load<Texture2D>("GUI Sprites/encounterSelectWindow");

        public Textbox(string text)
        {
            font = Game1.gameContent.Load<SpriteFont>("Fonts/textBoxFont");
            this.text = text;
        }
        

        public void Select()
        {

        }

        public void Update(GameTime gameTime)
        {
            scrollTimer--;
            if (scrollTimer <= 0 && scrollBool)
            {
                currText += text[index];
                index++;
                scrollTimer = 5;
                if (index >= text.Length)
                {
                    scrollBool = false;
                }
                if (currText.Length > 15)
                {
                    currText = currText.Remove(0, 1);
                }
            }
            if (!scrollBool)
            {
                if (scrollTimer <= 0 && currText.Length > 0)
                {
                    scrollTimer = 5;
                    currText = currText.Remove(0, 1);
                }
                else if (currText.Length == 0)
                {
                    scrollTimer = 5;
                    complete = true;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.DrawString(font, currText, new Vector2(position.X - 10, position.Y - 10), Color.Black);
        }

    }
}
