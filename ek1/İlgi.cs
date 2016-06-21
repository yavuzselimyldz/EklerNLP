using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ek1
{
    class İlgi: IEk
    {
     
        private string[] Dizi = new string[] { "in-İNCE_DÜZ_ÜNLÜ", "ın-KALIN_DÜZ_ÜNLÜ", "un-KALIN_YUVARLAK_ÜNLÜ", "ün-İNCE_YUVARLAK_ÜNLÜ" };
        private EkTürleri Tür = EkTürleri.ÜnlüHarfİleBaşlayanEk;
        private string KÜnsüzü = "n";

        public string[] EkDizisi()
        {
            return Dizi;
        }

        public EkTürleri EkTürü()
        {
            return Tür;
        }

        public string KaynastırmaÜnsüzü()
        {
            return KÜnsüzü;
        }

        public string İşlet(string Kelime)
        {
            return İşletici.İşletici1(Kelime, EkDizisi(), EkTürü(),KaynastırmaÜnsüzü());
        }


     
    }
}
