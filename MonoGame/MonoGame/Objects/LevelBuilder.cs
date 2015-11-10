using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;

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

        Dictionary<string, TileFactory.TileType> tileDictionary = new Dictionary<string, TileFactory.TileType>();
        Dictionary<string, GrassFactory.GrassType> grassDictionary = new Dictionary<string, GrassFactory.GrassType>();
        Dictionary<string, LedgeFactory.LedgeType> ledgeDictionary = new Dictionary<string, LedgeFactory.LedgeType>();
        Dictionary<string, BuildingFactory.BuildingType> buildingDictionary = new Dictionary<string, BuildingFactory.BuildingType>();

        public LevelBuilder(Level currentLevel)
        {
            level = currentLevel;
            factory = new SpriteFactory();
            tileFactory = new TileFactory();
            grassFactory = new GrassFactory();
            ledgeFactory = new LedgeFactory();
            buildingFactory = new BuildingFactory();
            tileDictionary.Add("W", TileFactory.TileType.wallTile);
            tileDictionary.Add("T", TileFactory.TileType.treeTile);
            grassDictionary.Add("G", GrassFactory.GrassType.shortGrass);
            ledgeDictionary.Add("M", LedgeFactory.LedgeType.ledgeMiddle);
            ledgeDictionary.Add("R", LedgeFactory.LedgeType.ledgeRightEnd);
            ledgeDictionary.Add("L", LedgeFactory.LedgeType.ledgeLeftEnd);
            buildingDictionary.Add("I", BuildingFactory.BuildingType.pokeCenterLeft);
            buildingDictionary.Add("O", BuildingFactory.BuildingType.pokeCenterRight);
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
                        }
                        level.levelBuildings.Add(building);
                    }
                    xCoord += spacingIncrement * events;
                }
            }

            return player;
        }
    }
}
