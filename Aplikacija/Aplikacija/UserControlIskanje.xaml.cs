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
    /// Interaction logic for UserControlIskanje.xaml
    /// </summary>
    public partial class UserControlIskanje : UserControl
    {

        public delegate void besedilo(object sender, string text, string upper, string lower);
        public event besedilo OnBesedilo;

        public UserControlIskanje()
        {
            InitializeComponent();
        }

        private void iskanje_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(OnBesedilo != null)
            {
                string text = iskanje.Text;
                string upper = text.ToUpper();
                string lower = text.ToLower();

                OnBesedilo(this, text, upper, lower);

            }


        }
    }
}
