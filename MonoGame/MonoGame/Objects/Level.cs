using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoGame
{
    public class Level
    {
        Game1 game;
        public Player player;
        public LevelBuilder builder;
        CollisionDetection collision;
        public List<Tile> levelTiles = new List<Tile>();
       
        public Level(string fileName, Game1 game)
        {
            this.game = game;
            builder = new LevelBuilder(this);
            player = builder.Build(fileName);
            collision = new CollisionDetection(player, game);
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in levelTiles)
            {
                tile.Draw(spriteBatch, tile.position, Color.White);
            }
            player.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            foreach (Tile tile in levelTiles)
            {
                tile.Update(gameTime);
            }
            collision.Detect(player, levelTiles);
            player.Update(gameTime);
        }
    }
}
