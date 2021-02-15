using System;

namespace Worm2
{
    public class Eye
    {
        private double X1, X2, X3, X4;
        private double Y1, Y2, Y3, Y4;
        private double[,] WInpHiden = new double[4, 4];
        private double[,] WInpLast = new double[4, 4];

        public Eye()
        {
            (X1, X2, X3, X4) = InitializingView();
            FillArray(ref WInpHiden);
            FillArray(ref WInpLast);
        }
        
        private (double X1, double X2, double X3, double X4) InitializingView()
        {
            Random random = new Random();
            X1 = random.NextDouble();
            X2 = random.NextDouble();
            X3 = random.NextDouble();
            X4 = random.NextDouble();
            return (X1, X2, X3, X4);
        }

        private void FillArray(ref double[,] arr)
        {
            Random rand = new Random();
            for (var r = 0; r < 4; r++)
            {
                for (var c = 0; c < 4; c++)
                {
                    arr[r, c] = rand.NextDouble();
                }
            }
        }

        private (double Z1, double Z2, double Z3, double Z4) ProcessNeuron()
        {
            double W1, W2, W3, W4;
            Y1 = WInpHiden[0, 0] * X1 + WInpHiden[1, 0] * X2 + WInpHiden[2, 0] * X3 + WInpHiden[3,0] * X4;
            Y2 = WInpHiden[0, 1] * X1 + WInpHiden[1, 1] * X2 + WInpHiden[2, 1] * X3 + WInpHiden[3,1] * X4;
            Y3 = WInpHiden[0, 2] * X1 + WInpHiden[1, 2] * X2 + WInpHiden[2, 2] * X3 + WInpHiden[3,2] * X4;
            Y4 = WInpHiden[0, 3] * X1 + WInpHiden[1, 3] * X2 + WInpHiden[2, 3] * X3 + WInpHiden[3,3] * X4;
            Y1 = 1 / (1 + Math.Exp(-Y1));
            Y2 = 1 / (1 + Math.Exp(-Y2));
            Y3 = 1 / (1 + Math.Exp(-Y3));
            Y4 = 1 / (1 + Math.Exp(-Y4));
            W1 = WInpLast[0, 0] * Y1 + WInpLast[1, 0] * Y2 + WInpLast[2, 0] * Y3 + WInpLast[3, 0] * Y4;
            W2 = WInpLast[0, 1] * Y1 + WInpLast[1, 1] * Y2 + WInpLast[2, 1] * Y3 + WInpLast[3, 1] * Y4;
            W3 = WInpLast[0, 2] * Y1 + WInpLast[1, 2] * Y2 + WInpLast[2, 2] * Y3 + WInpLast[3, 2] * Y4;
            W4 = WInpLast[0, 3] * Y1 + WInpLast[1, 3] * Y2 + WInpLast[2, 3] * Y3 + WInpLast[3, 3] * Y4;
            return (W1, W2, W3, W4);
        }

        public void Learning()
        {
            ProcessNeuron();
        }
    }
}