using System.Windows.Media;

namespace Worm2
{
    public class Apple
    {
        public int Energy { get; set; } = 10;
        public Brush Color { get; private set; } = Brushes.Green;
        public int PosX { get; set; }
        public int PosY { get; set; }
    }
}