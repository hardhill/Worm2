using System;
using System.Collections.Generic;
using System.Linq;

namespace Worm2
{
    public class World
    {
        private const int APPLES = 100;
        private List<Dictionary<String,Object>> Items;
        private int Width = 140;
        private int Height = 100;

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
            int X = random.Next(141);
            int Y = random.Next(101);
            Items.Add(new Dictionary<string, object>(){{"worm",worm},{"X",X}, {"Y",Y}});
        }

        public Worm worm
        {
            get
            {
                Worm worm = Items.Find(i=>i.ContainsKey("worm")).First().Value as Worm;
                return worm;
            }
        }
    }
}