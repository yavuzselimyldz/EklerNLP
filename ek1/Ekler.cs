using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ek1
{
  public class Ekler
    {
        Cogul cogul = new Cogul();
        Belirtme belirtme = new Belirtme();
        Yönelme  yönelme = new Yönelme();
        Bulunma  bulunma = new Bulunma();
        Ayrılma  ayrılma = new Ayrılma();
        İlgi ilgi = new İlgi();
        İyelik iyelik = new İyelik();

       public Ekler()
       {
           


       }
     
        public string Belirtme_Eki_Getir(string Kelime)
       {

           return belirtme.İşlet(Kelime);
       }

        public string Çogul_Eki_Getir(string Kelime)
       {
           return cogul.İşlet(Kelime);

       }

       public string İlgi_Eki_Getir(string Kelime)
       {
           return ilgi.İşlet(Kelime);

       }

       public string İyelik_Eki_Getir(string Kelime)
       {

           return iyelik.İşlet(Kelime);

       }

       public string Bulunma_Eki_Getir(string Kelime)
       {

           return bulunma.İşlet(Kelime);
       }


       public string Yönelme_Eki_Getir(string Kelime)
       {

           return yönelme.İşlet(Kelime);
       }

       public string Ayrılma_Eki_Getir(string Kelime)
       {
           return ayrılma.İşlet(Kelime);

       }
    
    }
}
