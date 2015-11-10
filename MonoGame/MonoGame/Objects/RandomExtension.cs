using System;

namespace MonoGame
{
    public static class RandomExtension
    {
        static RandomExtension()
        {
        }

        public static double NextDouble(this Random random, double minValue, double maxValue)
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }

        public static int NextInt(this Random random, int minValue, int maxValue)
        {
            random = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            return random.Next(minValue, maxValue);
        }
    }
}
