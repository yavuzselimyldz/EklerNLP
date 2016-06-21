using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ek1
{

      public  class Belirtme : IEk
        {
            private string[] Dizi = new string[] { "i-İNCE_DÜZ_ÜNLÜ", "ı-KALIN_DÜZ_ÜNLÜ", "u-KALIN_YUVARLAK_ÜNLÜ", "ü-İNCE_YUVARLAK_ÜNLÜ" };
            private EkTürleri Tür = EkTürleri.ÜnlüHarfİleBaşlayanEk;
            private string KÜnsüzü = "y";

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

      public   class Yönelme : IEk
        {
            private string[] Dizi = new string[] { "a-KALIN_ÜNLÜ", "e-İNCE_ÜNLÜ" };
            private EkTürleri Tür = EkTürleri.ÜnlüHarfİleBaşlayanEk;
            private string KÜnsüzü = "y";

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

      public  class Bulunma : IEk

        {
            private string[] Dizi = new string[] { "de-İNCE_ÜNLÜ", "da-KALIN_ÜNLÜ" };
            private EkTürleri Tür = EkTürleri.ÜnsüzHarfİleBaşlayanEk;
            private string KÜnsüzü = "";

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

      public class Ayrılma : IEk

    {
        private string[] Dizi = new string[] { "den-İNCE_ÜNLÜ", "dan-KALIN_ÜNLÜ" };
        private EkTürleri Tür = EkTürleri.ÜnsüzHarfİleBaşlayanEk;
        private string KÜnsüzü = "";

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
