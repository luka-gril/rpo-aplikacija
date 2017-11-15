using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace Aplikacija
{

    public class Uporabnik {

        public string mIme { get; set; }
        public string mPriimek { get; set; }
        public string mVzdevek { get; set; }
        [XmlElement(IsNullable = true)]
        public BitmapSource mSlika { get; set; }

        [XmlIgnore]
        public string mPodatki {
            get {
                return mIme + " " + mVzdevek + " " + mPriimek; 
            }
        }

        public Uporabnik() {

        }

        public Uporabnik(string ime, string priimek, string vzdevek, BitmapSource slika){
            mIme = ime;
            mPriimek = priimek;
            mVzdevek = vzdevek;
            mSlika = slika;
        }

        public override string ToString(){
            return mIme + " " + mVzdevek + " " + mPriimek;
        }


    }
}
