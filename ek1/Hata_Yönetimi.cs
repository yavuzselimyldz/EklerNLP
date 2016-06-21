using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ek1
{
    public class TurkceOlmayanKelime : Exception
    {
        private string Önerilen;
      
        public TurkceOlmayanKelime(string Kelime) : base("Türkce Olmayan Bir Kelime Girdisi Kullanılamaz." )

        {
            Önerilen = Zemberek_Aracı.Kelime_Öner(Kelime);
            
        }
    }

    public class TanımlanamayanEkTürü : Exception
    {
        public TanımlanamayanEkTürü(EkTürleri EkTürü) : base("Tanımlanamayan ek tipi => "+ EkTürü)

        {
           

        }


    }
}
