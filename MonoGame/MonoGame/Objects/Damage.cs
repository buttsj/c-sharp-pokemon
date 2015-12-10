using System;

namespace MonoGame
{
    public class Damage
    {

        private double stab = 1.5;

        /*private double noEffect = 0;
        private double halfEffect = 0.5;
        private double normalEffect = 1;
        private double doubleEffect = 2;*/

        private double critical = 1;
        //private double critical = 2;

        private Random rand;
        

        public Damage()
        {
        }

        public double DetermineEffect(string typeMon1, string typeMon2)
        {
            double ret = 1;
            rand = new Random();
            // effectiveness not implemented yet
            return ret;
        }


        public int CalculateDamage(Monster playMon, Monster enemMon, Move move)
        {
            double dmg = (((2 * playMon.level + 10)/250) * (playMon.currAtk / enemMon.currDef) * move.basePower + 2);
            double mod = stab * DetermineEffect(playMon.type, enemMon.type) * critical * RandomExtension.NextDouble(rand, 0.85, 1);
            dmg = dmg * mod;
            return (int)dmg;
        }
    }
}
