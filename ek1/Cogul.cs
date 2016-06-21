using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ek1
{
    class Cogul : IEk
    {
        private  string[] Dizi = new string[]{"lar-KALIN_ÜNLÜ","ler-İNCE_ÜNLÜ"};

        private  EkTürleri Tür = EkTürleri.ÜnsüzHarfİleBaşlayanEk;

        private  string KÜnsüzü = "";
       
        public string[] EkDizisi()
        {
            
            return Dizi;
        }

        public  EkTürleri EkTürü()
        {
            return Tür;
        }

        public  string KaynastırmaÜnsüzü()
        {
            return KÜnsüzü;
        }

       

        public string İşlet(string Kelime)
        {
            return İşletici.İşletici1(Kelime, EkDizisi(), EkTürü(), KaynastırmaÜnsüzü());
        }
    }
}
