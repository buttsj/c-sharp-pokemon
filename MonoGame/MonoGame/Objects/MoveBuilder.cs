using System.Collections.Generic;
using System.IO;
using System;

namespace MonoGame
{
    public class MoveBuilder
    {
        public Dictionary<string, Move> moveList = new Dictionary<string, Move>();
        string fileName;

        public MoveBuilder(string fileName)
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
                string name = words[0];
                string type = words[1];
                int power = 0;
                int acc = 0;
                if (words[2] != "-")
                {
                    power = Int32.Parse(words[2]);
                }
                if (words[3] != "-")
                {
                    acc = Int32.Parse(words[3]);
                }
                int pp = Int32.Parse(words[4]);
                moveList.Add(name, new Move(name, type, power, acc, pp));
            }
        }
    }
}
