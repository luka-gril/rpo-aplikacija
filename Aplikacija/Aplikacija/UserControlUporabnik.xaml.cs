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
    /// Interaction logic for UserControlUporabnik.xaml
    /// </summary>
    public partial class UserControlUporabnik : UserControl
    {
        Uporabnik upo = new Uporabnik();

        public UserControlUporabnik()
        {
            InitializeComponent();

            upo.Ime = "John";
            upo.Priimek = "Doe";
            upo.Vzdevek = "JDoe";
            upo.Slika = new BitmapImage(new Uri(@"/slike/city.jpg", UriKind.Relative));

            ime_priimekUpo.Content = string.Join(" ", upo.Ime, upo.Priimek);
            vzdevekUpo.Content = upo.Vzdevek;           
            slikaUpo.Source = upo.Slika;
        }
    }
}
