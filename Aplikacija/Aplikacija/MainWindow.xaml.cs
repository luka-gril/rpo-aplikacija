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

namespace Aplikacija
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();



            //List<MenuVrstica> menu = new List<MenuVrstica>();
            //menu.Add(new MenuVrstica() { Ime = "IGRE", Ikona = new BitmapImage(new Uri(@"/slike/1f608.png", UriKind.Relative))  });
            //menu.Add(new MenuVrstica() { Ime = "LESTVICA", Ikona = new BitmapImage(new Uri(@"/slike/1f60e.png", UriKind.Relative)) });
            //menu.Add(new MenuVrstica() { Ime = "NASTAVITVE", Ikona = new BitmapImage(new Uri(@"/slike/1f637.png", UriKind.Relative)) });

            //tabCont.ItemsSource = menu;

            
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
