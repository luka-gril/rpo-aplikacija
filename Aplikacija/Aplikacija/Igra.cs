using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Media.Imaging;

namespace Aplikacija
{
    public class Igra : INotifyPropertyChanged
    {
        private string naziv;
        private string naziv_kratko;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(""));
                }
            }
        }
        public string Naziv_kratko
        {
            get { return naziv_kratko; }
            set
            {
                naziv_kratko = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(""));
                }
            }
        }

        public string Format
        {
            get { return this.Naziv; }
        }

        public Igra()
        {
            naziv = "/";
        }
    }
}
