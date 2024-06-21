using System;

namespace AutoClicker.Helpers
{
    public static class Rand
    {
        private static Random random = new Random();

        public static int Int(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }

        public static int Int(int maxValue)
        {
            return random.Next(maxValue);
        }
    }
}
