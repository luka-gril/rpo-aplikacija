using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace Aplikacija
{
    /// <summary>
    /// Interaction logic for UserControlUporabnik.xaml
    /// </summary>
    public partial class UserControlUporabnik : UserControl
    {
        //  Uporabnik upo = new Uporabnik();
        ObservableCollection<Uporabnik> uporabnik = new ObservableCollection<Uporabnik>();

        public UserControlUporabnik()
        {
            InitializeComponent();

            XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<Uporabnik>));
            string pot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string celaPot = System.IO.Path.Combine(pot, "xml_files/Uporabnik.xml");
            TextReader reader = new StreamReader(celaPot);
            uporabnik = (ObservableCollection<Uporabnik>)ser.Deserialize(reader);
            reader.Close();

            foreach (var el in uporabnik)
            {
                ime_priimekUpo.Content = el.Ime + " " + el.Priimek.ToString();
                vzdevekUpo.Content = el.Vzdevek;
                slikaUpo.Source = el.Slika;
            }

      


        }
    }
}
