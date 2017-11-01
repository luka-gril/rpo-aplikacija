using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Aplikacija
{
    public class MenuVrstica
    {
        private string _ime;
        private BitmapSource _ikona;

        public string Ime
        {
            set { _ime = value; }
            get { return _ime; }
        }

        public BitmapSource Ikona
        {
            set{ _ikona = value; }
            get { return _ikona; }
        }
    }
}
