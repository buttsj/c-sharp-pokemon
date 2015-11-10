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
        public List<Grass> levelGrass = new List<Grass>();
        public List<Ledge> levelLedges = new List<Ledge>();
        public List<Building> levelBuildings = new List<Building>();
       
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
            foreach (Grass grass in levelGrass)
            {
                grass.Draw(spriteBatch, grass.position, Color.White);
            }
            foreach (Ledge ledge in levelLedges)
            {
                ledge.Draw(spriteBatch, ledge.position, Color.White);
            }
            foreach (Building building in levelBuildings)
            {
                building.Draw(spriteBatch, building.position, Color.White);
            }
            player.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            foreach (Tile tile in levelTiles)
            {
                tile.Update(gameTime);
            }
            foreach (Grass grass in levelGrass)
            {
                grass.Update(gameTime);
            }
            foreach (Ledge ledge in levelLedges)
            {
                ledge.Update(gameTime);
            }
            foreach (Building building in levelBuildings)
            {
                building.Update(gameTime);
            }
            collision.Detect(player, levelTiles, levelGrass, levelLedges, levelBuildings);
            player.Update(gameTime);
        }
    }
}
