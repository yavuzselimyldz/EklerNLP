using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ek1
{
    /* 
         ******************************************* EKLER_TR ***************************************************************
        
         Her Ek kendine ait bir ek dizisi, ek türü(ünlü-ünsüz harf ile başlayan) ve kaynaştırma ünsüzü (y,ş,s,n)
         barındırmak zorundadır.Bu sebeple her ek tarafından implemente edilmek üzere Ekdizisi() Ektürü() KaynastırmaÜnsüzü()
         İşlet() metodlarını içerek IEk ve Ektürleri arayüzleri oluşturuldu. 

      */

    interface IEk
    {
      

        string[] EkDizisi();
        EkTürleri EkTürü();
        string KaynastırmaÜnsüzü();
        string İşlet(string Kelime);
        
    }

 
    public enum EkTürleri
    {

        ÜnlüHarfİleBaşlayanEk,
        ÜnsüzHarfİleBaşlayanEk
    }

    interface ISesOlayları
    {



    }


}
