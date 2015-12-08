using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    public class Exit
    {
        public float xpos = 0, ypos = 0;
        public Vector2 position = new Vector2(0, 0);
        public string destination = "";
        public string source = "";
        public IAnimatedSprite sprite;
        
        public Exit(IAnimatedSprite sprite, Vector2 position)
        {
            this.sprite = sprite;
            this.position = position;
        }

        public Rectangle GetBoundingBox()
        {
            return sprite.GetBoundingBox(position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position, Color.White);
        }
    }
}
