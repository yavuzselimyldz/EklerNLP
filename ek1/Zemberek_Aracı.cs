using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using net.zemberek.tr.yapi;
using net.zemberek.erisim;
using net.zemberek.yapi;

namespace ek1
{
 public static class Zemberek_Aracı
    {
      private static  Zemberek zmb = new Zemberek(new TurkiyeTurkcesi());
       
      public static bool Turkce_Denetle(string Kelime)
        {

            return zmb.kelimeDenetle(Kelime);
           
        }

      public static string Kelime_Öner(string Kelime)
        {
            var tahminler = zmb.oner(Kelime);
            if (tahminler.Any())
            {
                return tahminler[0];
            }
            return Kelime;
           
        }

      public static Kelime[] cozumleyici(string Kelime)
        {
            
            return  zmb.kelimeCozumle(Kelime);


        }
        
    }
}
