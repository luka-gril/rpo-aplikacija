using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace Aplikacija
{
    public class Uporabnik : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _ime;
        private string _priimek;
        private string _vzdevek;
        private BitmapSource _slika;

        public string Ime
        {
            set
            {
                _ime = value;
                OnPropertyChanged("Ime");
                OnPropertyChanged("Ime_Priimek");
            }
            get { return _ime; }
        }

        public string Priimek
        {
            set
            {
                _priimek = value;
                OnPropertyChanged("Priimek");
                OnPropertyChanged("Ime_Priimek");
            }
            get { return _priimek; }
        }

        [XmlIgnore]
        public string Ime_Priimek
        {
            set
            {
                _ime = value;
                _priimek = value;
                OnPropertyChanged("Ime_Priimek");
            }
            get { return _ime + " " + _priimek; }
        }

        public string Vzdevek
        {
            set
            {
                _vzdevek = value;
                OnPropertyChanged("Vzdevek");
            }
            get { return _vzdevek; }
        }

        [XmlIgnore]
        public BitmapSource Slika
        {
            set
            {
                _slika = value;
                OnPropertyChanged("Slika");
            }
            get
            {
                return _slika;
            }
        }


        [XmlElement("Slika")]                           // vir: http://stackoverflow.com/questions/18841690/serialize-and-store-an-image-in-an-xml-file
        public byte[] ImageBuffer
        {

            get
            {
                byte[] imageBuffer = null;
                if (Slika != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        var encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(Slika));
                        encoder.Save(stream);
                        imageBuffer = stream.ToArray();
                    }
                }
                return imageBuffer;
            }

            set
            {
                if (value == null)
                {
                    Slika = null;
                }
                else
                {
                    using (var stream = new MemoryStream(value))
                    {
                        var decoder = BitmapDecoder.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                        Slika = decoder.Frames[0];
                    }
                }
            }

        }



    }
}
