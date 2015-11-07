﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoGame
{
    public class Level
    {
        Game1 game;
        public Player player;
        public LevelBuilder builder;

        public List<Tile> levelTiles = new List<Tile>();
       
        public Level(string fileName)
        {
            game = Game1.GetInstance();
            builder = new LevelBuilder(this, game);
            player = builder.Build(fileName);
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
            player.Update(gameTime);
        }
    }
}
