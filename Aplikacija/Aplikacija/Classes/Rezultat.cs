using System.Xml.Serialization;

namespace Aplikacija {

    public class Rezultat {

        public string mUporabnik { get; set; }
        public string mImeIgre { get; set; }
        public string mImeMape { get; set; }
        public int mRezultat { get; set; }

        [XmlIgnore]
        public string mPodatki{
            get{
                return mUporabnik + " " + mImeIgre + " " + mImeMape + " " + mRezultat.ToString();
            }
        }

        public Rezultat() {

        }

        public Rezultat(string uporabnik, string imeIgre, string imeMape, int rezultat) {
            mUporabnik = uporabnik;
            mImeIgre = imeIgre;
            mImeMape = imeMape;
            mRezultat = rezultat;
        }


    }

}
