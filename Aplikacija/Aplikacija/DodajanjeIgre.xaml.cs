using System.Windows;

namespace Aplikacija {

    public partial class DodajanjeIgre : Window {

        public DodajanjeIgre(){
            InitializeComponent();
        }

        private void DodajIgro(object sender, RoutedEventArgs e){
            string imeIgre = ImeIgre.Text;
            string potDoIgre = PotIgre.Text;
            if (imeIgre.Length == 0 || potDoIgre.Length == 0) {
                // TODO Eden od podatkov ali pa oba nista vnesena, izpisi opozorilo
                return;
            }
            Igra novaIgra = new Igra(imeIgre, potDoIgre);
            ((MainWindow)Application.Current.MainWindow).DodajIgro(novaIgra);
            this.Close();
        }

        private void ImeIgre_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Izhod_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
