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
using System.Xml.Linq;
using Microsoft.Win32;

namespace Aplikacija
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Igra> seznam_igre = new ObservableCollection<Igra>();

        ObservableCollection<Uporabnik> uporabnik = new ObservableCollection<Uporabnik>();
        
        UserControlUporabnik ucUpo = new UserControlUporabnik();
        List<UserControlUporabnik> UC_list = new List<UserControlUporabnik>();

        public MainWindow()
        {
            InitializeComponent();

            WindowState = WindowState.Maximized;

            //string p = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            //string cp = System.IO.Path.Combine(p, "slike/city.jpg");
            //uporabnik.Add(new Uporabnik { Ime = "Joe", Priimek = "Doe", Vzdevek = "JD", Slika = new BitmapImage(new Uri(cp, UriKind.RelativeOrAbsolute)) });


            UC_list.Add(ucUpo);
            UC_list.Add(upoIgre);
            UC_list.Add(upoLes);
            UC_list.Add(upoNas);

            //NASTAVITVE
            NasIme.Text = upoNas.ime_priimekUpo.Content.ToString();
            NasPriimek.Text = upoNas.ime_priimekUpo.Content.ToString();
            NasVzdevek.Text = upoNas.vzdevekUpo.Content.ToString();
            NasSlika.Source = upoNas.slikaUpo.Source;
            
            DataContext = this;
            try
            {

                XmlSerializer deserializer = new XmlSerializer(typeof(ObservableCollection<Igra>));
                string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string fullPath = System.IO.Path.Combine(path, "xml_files/IgreDefault.xml");
                TextReader tr = new StreamReader(fullPath);
                seznam_igre.Clear();
                seznam_igre = (ObservableCollection<Igra>)deserializer.Deserialize(tr);
                tr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Napaka! Ne morem prebrati iger: " + ex.Message);
            }

            listview_seznam_igre.ItemsSource = seznam_igre;



        }

        private void Shrani_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Igra>));
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fullPath = System.IO.Path.Combine(path, "xml_files/IgreDefault.xml");
            MessageBox.Show(fullPath);
            using (TextWriter writer = new StreamWriter(fullPath))
            {
                serializer.Serialize(writer, seznam_igre);
                writer.Close();
            }
        }

        private void listviewitem_seznam_igre_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Igra_okno igra_okno = new Igra_okno();
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fullPath = System.IO.Path.Combine(path, "slike/Call_of_Duty_Cover.jpg");
            //MessageBox.Show(listview_seznam_igre.SelectedIndex.ToString());

            igra_okno.Background = new ImageBrush(new BitmapImage(new Uri(fullPath, UriKind.Absolute)));
            igra_okno.ShowDialog();
            
        }


        //Shrani Spremembe stika
        private void Shrani_Nastavitve_Click(object sender, RoutedEventArgs e)
        {            
            ucUpo.ime_priimekUpo.Content = NasIme.Text + " " + NasPriimek.Text;
            ucUpo.vzdevekUpo.Content = NasVzdevek.Text;
            ucUpo.slikaUpo.Source = NasSlika.Source;

            uporabnik.Add(new Uporabnik { Ime = NasIme.Text, Priimek = NasPriimek.Text, Vzdevek = NasVzdevek.Text, Slika = (BitmapSource)NasSlika.Source });

            foreach (var uc in UC_list)
            {
                foreach(var el in uporabnik)
                {
                    uc.ime_priimekUpo.Content = el.Ime_Priimek;
                    uc.vzdevekUpo.Content = el.Vzdevek;
                    uc.slikaUpo.Source = el.Slika;
                }

            }

            
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Uporabnik>));
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fullPath = System.IO.Path.Combine(path, "xml_files/Uporabnik.xml");
            using (TextWriter writer = new StreamWriter(fullPath))
            {
                serializer.Serialize(writer, uporabnik);
                writer.Close();
            }
        }


        private void slika_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openfile.ShowDialog() == true)
            {
                NasSlika.Source = new BitmapImage(new Uri(openfile.FileName));
            }
        }

        private void iskanjeIgre_OnBesedilo(object sender, string text, string upper, string lower)
        {
            var filtered = from emp in seznam_igre
                           let ename = emp.Naziv
                           where
                           ename.StartsWith(text) || ename.StartsWith(upper) || ename.Contains(text)
                           select emp;

            listview_seznam_igre.ItemsSource = filtered;
            
        }
    }
}
