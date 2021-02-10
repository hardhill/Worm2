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
        private World world;
        Rectangle _rectangle;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void MainForm_Loaded(object sender, RoutedEventArgs e)
        {
            // создадим мир
            world = new World();
            //посеем яблоки
            world.SeedApple();
            //родим червя
            world.SeedWorm();
            (world.worm.PosX,world.worm.PosY) = world.RandomPosition();
            world.worm.OnLivesChanged += Worm_OnLivesChanged;
            _rectangle = new Rectangle();
            
            _rectangle.Width = world.worm.SizeHead;
            _rectangle.Height = world.worm.SizeHead;
            _rectangle.Fill = world.worm.Color;
            Field.Children.Add(_rectangle);
            Canvas.SetLeft(_rectangle,-100);
            

        }


        private void Worm_OnLivesChanged(object obj, Directions direct, int posx, int posy)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {

                Worm worm = (obj as Worm);
                if (posx < 0)
                {
                    posx = world.Width + posx + 1;
                }else if (posx > world.Width)
                {
                    posx = posx - world.Width - 1;
                }
                worm.PosX = posx;
                Canvas.SetLeft(_rectangle,worm.PosX*world.Dimantion);
                Canvas.SetTop(_rectangle,worm.PosY*world.Dimantion);
                    
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
            world.worm.StartLive();
        }
    }

    
}