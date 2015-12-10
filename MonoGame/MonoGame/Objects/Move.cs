
namespace MonoGame
{
    public class Move
    {
        public string name;
        public string type;
        public int basePower;
        public int acc;
        public int pp;

        public Move(string moveName, string type, int basePower, int acc, int pp)
        {
            name = moveName;
            this.basePower = basePower;
            this.type = type;
            this.acc = acc;
            this.pp = pp;
        }

    }
}
