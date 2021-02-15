using System;

namespace Worm2
{
    public class Util
    {
        public static float NextFloat(Random random)
        {
            double val = random.NextDouble(); // range 0.0 to 1.0
            val -= 0.5; // expected range now -0.5 to +0.5
            val *= 2; // expected range now -1.0 to +1.0
            return float.MaxValue * (float)val;
        }

        
    }
}