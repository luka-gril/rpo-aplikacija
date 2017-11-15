using System.Windows.Controls;


namespace Aplikacija
{

    public partial class UserControlUporabniki : UserControl
    {

        public delegate void SendInfoSelect(object sender, Uporabnik uporabnik);
        public event SendInfoSelect UserClicked;

        public UserControlUporabniki()
        {
            InitializeComponent();
        }

        private void UserSelected(object sender, SelectionChangedEventArgs e)
        {
            if (Uporabniki.SelectedItem != null)
            {
                Uporabnik uporabnik = (Uporabnik) Uporabniki.SelectedItem;
                UserClicked(this, uporabnik);
            }
        }

    }
}
