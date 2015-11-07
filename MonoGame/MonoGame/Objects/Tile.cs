using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    public class Tile
    {
        public float xpos = 0, ypos = 0;
        public ITileState state;
        public enum TileType { wall, tree}
        public Vector2 position = new Vector2(0, 0);
        
        public Tile(Game1 game, Tile.TileType type, Vector2 position)
        {
            if (type == TileType.wall)
            {
                state = new WallTileState(game);
            }
            if (type == TileType.tree)
            {
                state = new TreeTileState(game);
            }
            this.position = position;
        }

        public void Update(GameTime gameTime)
        {
            state.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            state.Draw(spriteBatch, location, color);
        }
    }
}
