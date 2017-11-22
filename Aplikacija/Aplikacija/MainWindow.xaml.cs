using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace Aplikacija {

    public partial class MainWindow : Window {

        public ObservableCollection<Uporabnik> mUporabniki = new ObservableCollection<Uporabnik>();
        public ObservableCollection<Igra> mIgre = new ObservableCollection<Igra>();
        private Igra mIzbranaIgra = null;


        public MainWindow() {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            DeserializirajIgre();
            DeserializirajUporabnike();
            SeznamIger.Igre.ItemsSource = mIgre;
            SeznamUporabnikov.Uporabniki.ItemsSource = mUporabniki;
        }

        // SERIALIZACIJA IN DESERALIZACIJA METODE
        #region SERIALIZIRANEJ IN DESERIALIZIRANJE
        private void SerializirajUporabnike() { 
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Uporabnik>));
            TextWriter textWriter = new StreamWriter(@"Uporabniki.xml");
            serializer.Serialize(textWriter, mUporabniki);
            textWriter.Close();
        }

        private void SerializirajIgre() {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Igra>));
            TextWriter textWriter = new StreamWriter(@"Igre.xml");
            serializer.Serialize(textWriter, mIgre);
            textWriter.Close();
        }

        private void DeserializirajUporabnike() {
            try {
                XmlSerializer deserializer = new XmlSerializer(typeof(ObservableCollection<Uporabnik>));
                TextReader textReader = new StreamReader(@"Uporabniki.xml");
                mUporabniki = (ObservableCollection<Uporabnik>)deserializer.Deserialize(textReader);
            }
            catch (FileNotFoundException e) { // Ob prvem zagonu aplikacije, ko še xml file ne bo obstajal bo vrnjena izjema, zato je try-catch zanka
                Console.WriteLine(e.ToString());
            }
        }

        private void DeserializirajIgre() {
            try{
                XmlSerializer deserializer = new XmlSerializer(typeof(ObservableCollection<Igra>));
                TextReader textReader = new StreamReader(@"Igre.xml");
                mIgre = (ObservableCollection<Igra>) deserializer.Deserialize(textReader);
            }
            catch (FileNotFoundException e){ // Ob prvem zagonu aplikacije, ko še xml file ne bo obstajal bo vrnjena izjema, zato je try-catch zanka
                Console.WriteLine(e.ToString());
            }
        }
        #endregion

        // !!!

        public void DodajIgro(Igra igra){
            mIgre.Add(igra);
            SerializirajIgre();
        }

        private void DodajUporabnika(object sender, RoutedEventArgs e){
            string ime = NasIme.Text;
            string priimek = NasPriimek.Text;
            string vzdevek = NasVzdevek.Text;
            //string sourceSlike = SourceSlike.Text;
            //Uri uriSlike = new Uri(sourceSlike, UriKind.Relative);
            //BitmapImage image = new BitmapImage(uriSlike);
            Uporabnik uporabnik = new Uporabnik(ime, priimek, vzdevek, null);
            mUporabniki.Add(uporabnik);
            SerializirajUporabnike();
            SeznamUporabnikov.Uporabniki.ItemsSource = mUporabniki;
        }


        // !!!

        private void IgraIzbrana(object sender, Igra igra) {
            mIzbranaIgra = igra;
            if(mIzbranaIgra.mRezultati != null){
                SeznamRezultatov.Rezultati.ItemsSource = mIzbranaIgra.mRezultati;
            }
            Console.WriteLine(mIzbranaIgra.mIme);
            /*
             * V tej metodi vzames podatke iz spremenljivke mIzbranaIgra in jih vstavis v vmesnik (ime, gumb za zagon,...)
             * 
             * */
        }

        private void UporabnikIzbran(object sender, Uporabnik uporabnik){
            Console.WriteLine(uporabnik.mPodatki);
            /*
             * Po želji lahko tu še kaj implementiramo, kakšen izpis al pa kaj  
             */
        }

        private void RezultatIzbran(object sender, Rezultat rezultat){
            Console.WriteLine(rezultat.mPodatki);
            /*
            * Po želji lahko tu še kaj implementiramo, kakšen izpis al pa kaj  
            */
        }

        private void OdpriDodajanjeIgre(object sender, RoutedEventArgs e) // Odpre okno za dodajanje igre
        {
            DodajanjeIgre di = new DodajanjeIgre();
            di.ShowDialog();
        }


    }
}
