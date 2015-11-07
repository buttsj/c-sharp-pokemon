using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;

namespace MonoGame
{
    public class LevelBuilder
    {
        Game1 game;
        Player player;
        Level level;
        int spacingIncrement = 16;
        ISpriteFactory factory;

        Dictionary<string, Tile.TileType> tileDictionary = new Dictionary<string, Tile.TileType>();

        public LevelBuilder(Level currentLevel, Game1 game)
        {
            this.game = game;
            level = currentLevel;
            factory = new SpriteFactory();
            tileDictionary.Add("W", Tile.TileType.wall);
            tileDictionary.Add("T", Tile.TileType.tree);
        }

        public Player Build(string fileName)
        {
            float xCoord = 0, yCoord = 0;
            StreamReader sr;
            sr = File.OpenText(Game1.GetInstance().Content.RootDirectory + "\\" + fileName);
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                yCoord += spacingIncrement;
                xCoord = 0;

                string[] words = line.Split(',');
                for (int i = 0; i < words.Length; i++)
                {
                    int events = 1;
                    if (words[i] == "P")
                    {
                        player = new Player(new Vector2(xCoord, yCoord));
                    }
                    if (tileDictionary.ContainsKey(words[i]))
                    {
                        Tile tile = new Tile(game, tileDictionary[words[i]], new Vector2(xCoord, yCoord));
                        level.levelTiles.Add(tile);
                    }
                    xCoord += spacingIncrement * events;
                }
            }

            return player;
        }
    }
}
