using System.Windows.Controls;


namespace Aplikacija {

    public partial class UserControlIgre : UserControl {

        public delegate void SendInfoSelect(object sender, Igra igra);
        public event SendInfoSelect GameClicked;

        public UserControlIgre(){
            InitializeComponent();
        }

        private void GameSelected(object sender, SelectionChangedEventArgs e){
            if(Igre.SelectedItem != null) { 
                Igra igra = (Igra) Igre.SelectedItem;
                GameClicked(this, igra);
            }
        }

    }
}