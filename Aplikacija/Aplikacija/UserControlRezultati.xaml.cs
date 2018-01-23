using System.Windows.Controls;


namespace Aplikacija
{

    public partial class UserControlRezultati : UserControl
    {

        public delegate void SendInfoSelect(object sender, Rezultat rezultat);
        public event SendInfoSelect ResultClicked;

        public UserControlRezultati()
        {
            InitializeComponent();
        }
/*
        private void ResultSelected(object sender, SelectionChangedEventArgs e)
        {
            if (Rezultati.SelectedItem != null)
            {
                Rezultat rezultat = (Rezultat)Rezultati.SelectedItem;
                ResultClicked(this, rezultat);
            }
        }
        */
    }
}
