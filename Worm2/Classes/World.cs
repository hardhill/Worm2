using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace Worm2
{
    public class World
    {
        private const int APPLES = 100;
        
        public int Width { get; } = 140;
        public int Height { get; }= 100;
        public int Dimantion { get; } = 8;
        public List<Apple> Apples;
        public Worm Worm;

        private Random random;
        
        public World()
        {
            random = new Random();
            Apples = new List<Apple>();
        }
        
        public void SeedApples()
        {
            for (var c = 0; c < APPLES; c++)
            {
                Apple apple = new Apple();
                apple.PosX = random.Next(141);
                apple.PosY = random.Next(101);
                Apples.Add(apple);
            }
        }

        public void SeedWorm()
        {
            Worm = new Worm();
            (Worm.PosX, Worm.PosY) = RandomPosition();
        }

        public (int PosX, int PosY) RandomPosition()
        {
            int X = random.Next(141);
            int Y = random.Next(101);
            return (X, Y);
        }
    }
}