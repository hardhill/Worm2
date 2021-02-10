using System;
using System.Collections.Generic;
using System.Linq;

namespace Worm2
{
    public class World
    {
        private const int APPLES = 100;
        private List<Dictionary<String,Object>> Items;
        public int Width { get; } = 140;
        public int Height { get; }= 100;
        public int Dimantion { get; } = 8;

        private Random random;
        
        public World()
        {
            random = new Random();
            Items = new List<Dictionary<string, object>>();
        }
        

        public void SeedApple()
        {
            for (var c = 0; c < APPLES; c++)
            {
                Apple apple = new Apple();
                int X = random.Next(141);
                int Y = random.Next(101);
                Items.Add(new Dictionary<string, object>(){{"apple",apple},{"X",X}, {"Y",Y}});
            }

        }

        public void SeedWorm()
        {
            Worm worm = new Worm();
            Items.Add(new Dictionary<string, object>(){{"worm",worm}});
        }

        public Worm worm
        {
            get
            {
                Worm worm = Items.Find(i=>i.ContainsKey("worm")).First().Value as Worm;
                return worm;
            }
        }

        public (int PosX, int PosY) RandomPosition()
        {
            int X = random.Next(141);
            int Y = random.Next(101);
            return (X, Y);
        }
    }
}