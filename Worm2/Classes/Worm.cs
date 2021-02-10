using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Worm2
{
    public class Worm
    {
        public delegate void LivesChanged(object obj, Directions direct,int PosX,int PosY);
        public event LivesChanged OnLivesChanged;

        private Timeout timeout;
        private readonly double INTERVAL =500;

        // lives - жизненная энергия
        public int Lives { get; private set; }
        public Vectors Vector { get; set; }

        public Brush Color { get; private set; }

        public int SizeHead { get; } = 8;
        public int PosX { get; set; }
        public int PosY { get; set; }
        // distance - дистанция на которую переместился червь
        public int Distance { get; private set; }
        private int DeltaDist;
        
        
        //напрвление
        private Directions Direction { get; set; }
        
        public Worm()
        {
            Lives = 300;
            PosX = 0;
            PosY = 0;
            Direction = Directions.North;
            DeltaDist = 1;
            Vector = new Vectors { X=0,Y=0};
            Color = Brushes.Brown;
            
        }
        public void StartLive()
        {
            timeout = new Timeout(() => {
                Move();
            }, INTERVAL);
            
        }
        private void Move()
        {
            
            Vector = ChangeDirection(Direction);
            Distance = Distance + GetDelta(Vector);
            PosX = PosX + Vector.X;
            PosY = PosY + Vector.Y;
            Lives--;
            if (Lives <= 0)
            {
                timeout.Stop();
            }
            else
            {
                OnLivesChanged?.Invoke(this, Direction, PosX, PosY);
            }
        }

        private int GetDelta(Vectors vector)
        {
            return vector.X != 0 || vector.Y != 0 ? 1 : 0;
        }

        private Vectors ChangeDirection(Directions direction)
        {
            
            Random random = new Random();
            int r = random.Next(2);
            switch (direction)
            {
                case Directions.North:
                case Directions.South:
                    Direction = r == 0 ? Directions.West : Directions.East;
                    break;
                case Directions.West:
                case Directions.East:
                    Direction = r == 0 ? Directions.North : Directions.South;
                    break;
            }
            switch (Direction)
            {
                case Directions.North:
                    Vector.X = 0; Vector.Y = -1;
                    break;
                case Directions.South:
                    Vector.X = 0; Vector.Y = 1;
                    break;
                case Directions.West:
                    Vector.X = -1; Vector.Y = 0;
                    break;
                case Directions.East:
                    Vector.X = 1; Vector.Y = 0;
                    break;
            }
            return Vector;
        }
    }
}
