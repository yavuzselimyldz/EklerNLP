using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ek1
{
    class İyelik : IEk
    {
        private string[] Dizi = new string[] { "i-İNCE_DÜZ_ÜNLÜ", "ı-KALIN_DÜZ_ÜNLÜ", "u-KALIN_YUVARLAK_ÜNLÜ", "ü-İNCE_YUVARLAK_ÜNLÜ" };
        private EkTürleri Tür = EkTürleri.ÜnlüHarfİleBaşlayanEk;
        private string KÜnsüzü = "s";

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
            return İşletici.İşletici1(Kelime, EkDizisi(), EkTürü(), KaynastırmaÜnsüzü());
        }
    }
}
