using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System;
using System.Diagnostics;

namespace MonoGame
{
    public class LevelBuilder
    {
        Player player;
        Level level;
        int spacingIncrement = 16;

        ISpriteFactory factory;
        TileFactory tileFactory;
        GrassFactory grassFactory;
        LedgeFactory ledgeFactory;
        BuildingFactory buildingFactory;
        EnemyFactory enemyFactory;

        Dictionary<string, TileFactory.TileType> tileDictionary = new Dictionary<string, TileFactory.TileType>();
        Dictionary<string, GrassFactory.GrassType> grassDictionary = new Dictionary<string, GrassFactory.GrassType>();
        Dictionary<string, LedgeFactory.LedgeType> ledgeDictionary = new Dictionary<string, LedgeFactory.LedgeType>();
        Dictionary<string, BuildingFactory.BuildingType> buildingDictionary = new Dictionary<string, BuildingFactory.BuildingType>();
        Dictionary<string, EnemyFactory.EnemyType> enemyDictionary = new Dictionary<string, EnemyFactory.EnemyType>();

        public LevelBuilder(Level currentLevel)
        {
            level = currentLevel;
            factory = new SpriteFactory();
            tileFactory = new TileFactory();
            grassFactory = new GrassFactory();
            ledgeFactory = new LedgeFactory();
            buildingFactory = new BuildingFactory();
            enemyFactory = new EnemyFactory();

            // trees
            tileDictionary.Add("W", TileFactory.TileType.treeTile);

            // pokecenter parts
            tileDictionary.Add("3", TileFactory.TileType.pokeEndCornerLeft);
            tileDictionary.Add("6", TileFactory.TileType.pokeEndCornerRight);
            tileDictionary.Add("1", TileFactory.TileType.pokeEndCounterLeft);
            tileDictionary.Add("8", TileFactory.TileType.pokeEndCounterRight);
            tileDictionary.Add("4", TileFactory.TileType.pokeHorizontal);
            tileDictionary.Add("5", TileFactory.TileType.pokeMiddleSection);
            tileDictionary.Add("2", TileFactory.TileType.pokeVerticalLeft);
            tileDictionary.Add("7", TileFactory.TileType.pokeVerticalRight);

            // exit tile
            tileDictionary.Add("B", TileFactory.TileType.exit);

            // grass
            grassDictionary.Add("G", GrassFactory.GrassType.shortGrass);

            // ledges
            ledgeDictionary.Add("M", LedgeFactory.LedgeType.ledgeMiddle);
            ledgeDictionary.Add("R", LedgeFactory.LedgeType.ledgeRightEnd);
            ledgeDictionary.Add("L", LedgeFactory.LedgeType.ledgeLeftEnd);

            // buildings
            buildingDictionary.Add("I", BuildingFactory.BuildingType.pokeCenterLeft);
            buildingDictionary.Add("O", BuildingFactory.BuildingType.pokeCenterRight);

            // npcs
            enemyDictionary.Add("E", EnemyFactory.EnemyType.rival);
            enemyDictionary.Add("Q", EnemyFactory.EnemyType.girl);
        }

        public Player Build(string fileName)
        {
            float xCoord = 0, yCoord = 0;
            StreamReader sr;
            sr = File.OpenText(Game1.GetInstance().Content.RootDirectory + "\\" + fileName);
            string line;
            int reference = 0;

            // LEVEL DESTINATIONS
            int currDest = 0;
            List<string> destinations = new List<string>();

            // LEVEL TILES
            List<TileFactory.TileType> tileChoices = new List<TileFactory.TileType>();
            tileChoices.Add(TileFactory.TileType.grass);
            tileChoices.Add(TileFactory.TileType.pokePlainFloor);
            int tileNumber = 0;

            // LEVEL DATA
            line = sr.ReadLine();
            string[] initialWords = line.Split(',');
            try
            {
                tileNumber = Int32.Parse(initialWords[0]);
            }
            catch (FormatException e)
            {
                Debug.WriteLine(e);
            }
            for (int i = 0; i < initialWords.Length; i++)
            {
                if (initialWords[i].Contains("Levels"))
                {
                    destinations.Add(initialWords[i]);
                }
            }

            // MAIN LEVEL
            while ((line = sr.ReadLine()) != null)
            {
                xCoord = 0;
                string[] words = line.Split(',');
                
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Length > 1)
                    {
                        try
                        {
                            string tmp = words[i].Remove(1);
                            reference = Int32.Parse(words[i][1].ToString());
                            words[i] = tmp;
                        }
                        catch
                        {
                            // exception here
                        }
                    }
                    if (xCoord % 32 == 0 && yCoord % 32 == 0)
                    {
                        Tile tile = tileFactory.builder(tileChoices[tileNumber], new Vector2(xCoord, yCoord));
                        level.levelBackground.Add(tile);
                    }
                    if (words[i] == "P")
                    {
                        player = new Player(new Vector2(xCoord, yCoord));
                    }
                    if (tileDictionary.ContainsKey(words[i]))
                    {
                        Tile tile = tileFactory.builder(tileDictionary[words[i]], new Vector2(xCoord, yCoord));
                        level.levelTiles.Add(tile);
                    }
                    if (grassDictionary.ContainsKey(words[i]))
                    {
                        Grass grass = grassFactory.builder(grassDictionary[words[i]], new Vector2(xCoord, yCoord));
                        level.levelGrass.Add(grass);
                    }
                    if (ledgeDictionary.ContainsKey(words[i]))
                    {
                        Ledge ledge = ledgeFactory.builder(ledgeDictionary[words[i]], new Vector2(xCoord, yCoord));
                        level.levelLedges.Add(ledge);
                    }
                    if (buildingDictionary.ContainsKey(words[i]))
                    {
                        Building building = buildingFactory.builder(buildingDictionary[words[i]], new Vector2(xCoord, yCoord));
                        if (words[i] == "I")
                        {
                            building.isDoor = true;
                            building.destination = destinations[currDest];
                            building.source = fileName;
                            currDest++;
                        }
                        level.levelBuildings.Add(building);
                    }
                    if (enemyDictionary.ContainsKey(words[i]))
                    {
                        Enemy enemy = enemyFactory.builder(enemyDictionary[words[i]], new Vector2(xCoord, yCoord));
                        level.levelEnemies.Add(enemy);
                    }
                    xCoord += spacingIncrement;
                }
                yCoord += spacingIncrement;
            }
            return player;
        }
    }
}
