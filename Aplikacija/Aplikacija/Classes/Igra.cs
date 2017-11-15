using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace Aplikacija
{

    public class Igra{

        public string mIme { get; set; }
        public string mPotDoIgre { get; set; }
        [XmlElement(IsNullable = true)]
        public ObservableCollection<Rezultat> mRezultati { get; set; }

        public Igra() {

        }

        public Igra(string ime, string potDoIgre){
            mIme = ime;
            mPotDoIgre = potDoIgre;
            mRezultati = new ObservableCollection<Rezultat>();
        }

        public void DodajRezultat(Rezultat rezultat) {
            mRezultati.Add(rezultat);
        }


    }

}
