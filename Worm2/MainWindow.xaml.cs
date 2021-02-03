using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Worm2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Worm worm;
        Rectangle rect;
        int PosX = 0, PosY = 0;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void MainForm_Loaded(object sender, RoutedEventArgs e)
        {
            //
            rect = new Rectangle();
            rect.Width = 8; rect.Height = 8;
            rect.Fill = Brushes.DeepPink;
            Field.Children.Add(rect);
            Random random = new Random();
            PosX = random.Next(141) * Convert.ToInt32(rect.Width);
            PosY = random.Next(101) * Convert.ToInt32(rect.Height);
            Canvas.SetLeft(rect, PosX); 
            Canvas.SetTop(rect, PosY);
            worm = new Worm();
            worm.OnLivesChanged += Worm_OnLivesChanged;
        }

        private void Worm_OnLivesChanged(object obj, int lives,Directions direct, Vectors vector)
        {
            Application.Current.Dispatcher.Invoke(new Action(() => {
                
                if (PosX < 800 && PosX > 0 && PosY > 0 && PosY < 1120)
                {
                    PosX = PosX + vector.X * Convert.ToInt32(rect.Width);
                    PosY = PosY + vector.Y * Convert.ToInt32(rect.Height);
                    Canvas.SetLeft(rect, PosX);
                    Canvas.SetTop(rect, PosY);
                }
                switch (direct)
                {
                    case Directions.North:
                        lblDirection.Content = "NORTH";
                        break;
                    case Directions.South:
                        lblDirection.Content = "SOUTH";
                        break;
                    case Directions.West:
                        lblDirection.Content = "WEST";
                        break;
                    case Directions.East:
                        lblDirection.Content = "EAST";
                        break;
                }
            }));
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            worm.StartLive();
        }
    }
}