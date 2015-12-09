using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using System.IO;

namespace MonoGame
{
    public class MonsterBuilder
    {
        public Dictionary<string, Monster> monsterList = new Dictionary<string, Monster>();
        string fileName;

        public MonsterBuilder(string fileName)
        {
            this.fileName = fileName;
            Build();
        }

        public void Build()
        {
            StreamReader sr;
            sr = File.OpenText(Game1.GetInstance().Content.RootDirectory + "\\" + fileName);
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                monsterList.Add(words[0], new Monster(words[0], Int32.Parse(words[1]), Int32.Parse(words[2]), Int32.Parse(words[3]), Int32.Parse(words[4]), Int32.Parse(words[5]), Int32.Parse(words[6]), words[7]));
            }
        }
    }
}
