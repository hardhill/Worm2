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
            world.SeedApples();
            //родим червя
            world.SeedWorm();
            world.Worm.OnLivesChanged += Worm_OnLivesChanged;
            
            _rectangle = new Rectangle();
            _rectangle.Width = world.Worm.SizeHead;
            _rectangle.Height = world.Worm.SizeHead;
            _rectangle.Fill = world.Worm.Color;
            Field.Children.Add(_rectangle);
            Canvas.SetLeft(_rectangle,-100);
            UpdateApple(world,Field);

        }

        private void UpdateApple(World world,Canvas field)
        {
                var apples = world.Apples;
                foreach (var apple in apples)
                {
                    Rectangle rect = new Rectangle();
                    rect.Fill = apple.Color;
                    rect.Width = 8;
                    rect.Height = 8;
                    field.Children.Add(rect);
                    Canvas.SetLeft(rect,apple.PosX*world.Dimantion);
                    Canvas.SetTop(rect,apple.PosY*world.Dimantion);
                }
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
                if (posy < 0)
                {
                    posy = world.Height + posy + 1;
                }else if (posy > world.Height)
                {
                    posy = posy - world.Height - 1;
                }
                worm.PosY = posy;
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
                lblLifes.Content = worm.Lives.ToString();
                lblDist.Content = worm.Distance.ToString();
            }));
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            world.Worm.StartLive();
        }
    }

    
}