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
        public Texture2D background;

        public List<Tile> levelTiles = new List<Tile>();
        public List<Grass> levelGrass = new List<Grass>();
        public List<Ledge> levelLedges = new List<Ledge>();
        public List<Building> levelBuildings = new List<Building>();
        public List<Enemy> levelEnemies = new List<Enemy>();
        public List<Tile> levelBackground = new List<Tile>();

        public Level(string fileName, Game1 game)
        {
            this.game = game;
            builder = new LevelBuilder(this);
            player = builder.Build(fileName);
            collision = new CollisionDetection(player, game);

            background = Game1.gameContent.Load<Texture2D>("Backgrounds/grass");
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in levelBackground)
            {
                if (game.camera.IsInView(tile.GetBoundingBox()))
                {
                    tile.Draw(spriteBatch, tile.position, Color.White);
                }
            }
            foreach (Ledge ledge in levelLedges)
            {
                if (game.camera.IsInView(ledge.GetBoundingBox()))
                {
                    ledge.Draw(spriteBatch, ledge.position, Color.White);
                }
            }
            foreach (Tile tile in levelTiles)
            {
                if (game.camera.IsInView(tile.GetBoundingBox()))
                {
                    tile.Draw(spriteBatch, tile.position, Color.White);
                }
            }
            foreach (Grass grass in levelGrass)
            {
                if (game.camera.IsInView(grass.GetBoundingBox()))
                {
                    grass.Draw(spriteBatch, grass.position, Color.White);
                }
            }
            foreach (Building building in levelBuildings)
            {
                if (game.camera.IsInView(building.GetBoundingBox()))
                {
                    building.Draw(spriteBatch, building.position, Color.White);
                }
            }
            foreach (Enemy enemy in levelEnemies)
            {
                if (game.camera.IsInView(enemy.state.GetBoundingBox(enemy.position)))
                {
                    enemy.Draw(spriteBatch);
                }
            }
            player.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            foreach (Tile tile in levelTiles)
            {
                if (game.camera.IsInView(tile.GetBoundingBox()))
                {
                    tile.Update(gameTime);
                }
            }
            foreach (Grass grass in levelGrass)
            {
                if (game.camera.IsInView(grass.GetBoundingBox()))
                {
                    grass.Update(gameTime);
                }
            }
            foreach (Ledge ledge in levelLedges)
            {
                if (game.camera.IsInView(ledge.GetBoundingBox()))
                {
                    ledge.Update(gameTime);
                }
            }
            foreach (Building building in levelBuildings)
            {
                if (game.camera.IsInView(building.GetBoundingBox()))
                {
                    building.Update(gameTime);
                }
            }
            foreach (Enemy enemy in levelEnemies)
            {
                if (game.camera.IsInView(enemy.state.GetBoundingBox(enemy.position)))
                {
                    enemy.Update(gameTime);
                }
            }
            collision.Detect(player, levelTiles, levelGrass, levelLedges, levelBuildings, levelEnemies);
            player.Update(gameTime);
        }
    }
}
