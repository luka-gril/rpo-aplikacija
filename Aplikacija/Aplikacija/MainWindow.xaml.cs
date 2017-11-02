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
using System.Xml.Serialization;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using System.IO;

namespace Aplikacija
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Igra> seznam_igre = new ObservableCollection<Igra>();

        public MainWindow()
        {
            InitializeComponent();


            try
            {

                XmlSerializer deserializer = new XmlSerializer(typeof(ObservableCollection<Igra>));
                TextReader tr = new StreamReader(@"IgreDefault.xml");
                seznam_igre.Clear();
                seznam_igre = (ObservableCollection<Igra>)deserializer.Deserialize(tr);
                tr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Napaka! Ne morem prebrati iger: " + ex.Message);
            }

            //List<MenuVrstica> menu = new List<MenuVrstica>();
            //menu.Add(new MenuVrstica() { Ime = "IGRE", Ikona = new BitmapImage(new Uri(@"/slike/1f608.png", UriKind.Relative))  });
            //menu.Add(new MenuVrstica() { Ime = "LESTVICA", Ikona = new BitmapImage(new Uri(@"/slike/1f60e.png", UriKind.Relative)) });
            //menu.Add(new MenuVrstica() { Ime = "NASTAVITVE", Ikona = new BitmapImage(new Uri(@"/slike/1f637.png", UriKind.Relative)) });

            //tabCont.ItemsSource = menu;
            listview_seznam_igre.ItemsSource = seznam_igre;



        }

        private void Shrani_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Igra>));
            using (TextWriter writer = new StreamWriter(@"IgreDefault.xml"))
            {
                serializer.Serialize(writer, seznam_igre);
                writer.Close();
            }
        }

        private void listviewitem_seznam_igre_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Gumb dela");
        }
    }
}
