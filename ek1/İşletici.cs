using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ek1
{
   public  class İşletici
    {
        #region Değişkenler

        private static string Kontrol_Harfi = string.Empty;
        private static string temp = string.Empty;
        private static int i, z;

        #endregion

        /*
           Her ek kendi ek dizisini,kelime verisini,ek türünü ve kaynaştırma ünsüzünü İşletici()  metoduna göndererek işlem yaptırır.
           Her ek dizisi uzunluğu sabit olmayan string dizileridir.Dizi çerisindeki her string ifade 2 parametreden oluşur.Birinci kısım
           ek ikinci kısım ise ekin uygulanabilmesi için gerekli koşuldur.Birbirlerinden (-) ile ayrılırlar.

       */
        public static string İşletici1(string Kelime,string[] EkDizisi,EkTürleri EkTürü,string KÜN)
       {
            Kontrol_Harfi = "";

            // Kelime verisinin her karakteri tek tek denetlenerek içerisinde istenmeyen türde bir özel karakter olup olmadığı denetleniyor.
            char[] karakter = Kelime.ToCharArray();
            for ( i = 0; i < Kelime.Length; i++)
            {
                if (!char.IsControl(karakter[i]) && !char.IsLetter(karakter[i]) && (karakter[i] != ' ') && !char.IsDigit(karakter[i]))
                {
                    // Kelime verisi içerisinde istenmeyen bir karaktere rastlanırsa Kelime içeriği değiştirilmeden metod içerisinden çıkılıyor.
                    goto end;
                }
            }

            if (Kelime == "")
            {
                // Gelen kelime verisi boş ise herhangi bir işlem yapılmadan metod içerisinden çıkılıyor.
                goto end;
            }

            else if(Kontrol.Kontrol_Rakam(char.Parse(Kelime.Substring(Kelime.Length-1,1))))
            {

                // Kelime verisi rakam ise yapılan işlemler.
                temp = İşletici1(Kontrol.Kontrol_Rakam_Dönüstür(Kelime.Substring(Kelime.Length - 1, 1)), EkDizisi, EkTürü, KÜN);
                Kelime += "’" + temp.Substring(Kontrol.Kontrol_Rakam_Dönüstür(Kelime.Substring(Kelime.Length - 1, 1)).Length, temp.Length - Kontrol.Kontrol_Rakam_Dönüstür(Kelime.Substring(Kelime.Length - 1, 1)).Length);


            }
            else
            {
                #region Ünsüz Harf İle Başlayan Ekler

                if (EkTürü == EkTürleri.ÜnsüzHarfİleBaşlayanEk)
                {
                    #region Kelimenin Son Harfi Ünlü İse
                    if (Kontrol.Execute(char.Parse(Kelime.Substring(Kelime.Length - 1, 1)), "ÜNLÜ_HARF"))
                    {
                        for ( i = 0; i < EkDizisi.Length; i++)
                        {
                            // Ünlü harf ile biten Kelime verisine ünsüz harf ile başlayan ek dizesi getirildiğinden son harf üzerinden işlem yapılıyor.
                            if (Kontrol.Execute(char.Parse(Kelime.Substring(Kelime.Length - 1, 1)), EkDizisi[i].Split('-')[1]))
                                Kelime += EkDizisi[i].Split('-')[0];

                        }

                    }
                    #endregion

                    #region Kelimenin Son Harfi Ünsüz İse
                    else
                    {
                        if (Kontrol.Execute(char.Parse(Kelime.Substring(Kelime.Length - 1, 1)), "FISTIKÇI_ŞAHAP"))
                        {
                            for (z = Kelime.Length - 1; z >= 0; z--)
                            {

                                for (i = 0; i < EkDizisi.Length; i++)
                                {
                                    if (Kontrol.Execute(char.Parse(Kelime.Substring(z, 1)), EkDizisi[i].Split('-')[1]))
                                    {
                                        // Kelime verisinin son harfi (f,s,t,k,ç,h,ş,p) harflerinden biri ise benzeşme olayı uygulanıyor.
                                        Kelime += SesOlayları.Yumusama.DiziSertleştirici(EkDizisi[i].Split('-')[0]);
                                        goto end;
                                    }
                                }

                            }

                        }
                        else
                        {

                            // Bazı Kelime verilerinin son iki harfide ünsüz olabildiğinden bu iç içe döngü kullanılarak veri içerisinde sondan geriye ilk ünlü harf üzerinden işlem yapılıyor. 
                            for (z = Kelime.Length - 1; z >= 0; z--)
                            {

                                for (i = 0; i < EkDizisi.Length; i++)
                                {
                                    if (Kontrol.Execute(char.Parse(Kelime.Substring(z, 1)), EkDizisi[i].Split('-')[1]))
                                    {
                                        Kelime += EkDizisi[i].Split('-')[0];
                                        goto end;
                                    }
                                }

                            }

                        }

                    }
                    #endregion
                }
                #endregion

                #region Ünlü Harf İle Başlayan Ekler
                else if (EkTürü == EkTürleri.ÜnlüHarfİleBaşlayanEk)
                {

                    #region Kelimenin Son Harfi Ünlü ise
                    if (Kontrol.Execute(char.Parse(Kelime.Substring(Kelime.Length - 1, 1)), "ÜNLÜ_HARF"))
                    {
                        if (SesOlayları.DüşmeÖzelDurum.DüşmeKontrol(Kelime))
                        {
                             // Kelime düşme özel duumuna sahipse ünlü harf düşürülüyor.
                             
                            Kontrol_Harfi = Kelime.Substring(Kelime.Length - 1, 1);
                            Kelime = Kelime.Remove(Kelime.Length - 1, 1);

                            for ( i = 0; i < EkDizisi.Length; i++)
                            {
                                if (Kontrol.Execute(char.Parse(Kontrol_Harfi), EkDizisi[i].Split('-')[1]))
                                    Kelime += EkDizisi[i].Split('-')[0];

                            }
                        }
                        else
                        {
                            for ( i = 0; i < EkDizisi.Length; i++)
                            {
                                // Ünlü harf ile biten kelime verisine ünlü harf ile başlayan bir ek getirildiğinden dolayı ek dizisi kaynaştırma ünsüzü ile beraber uygulanıyor.
                                    if (Kontrol.Execute(char.Parse(Kelime.Substring(Kelime.Length - 1, 1)), EkDizisi[i].Split('-')[1]))
                                    Kelime += KÜN + EkDizisi[i].Split('-')[0];

                            }
                        }

                    }
                    #endregion

                    #region Kelimenin Son Harfi Sert Ünsüz İse
                    else if (Kontrol.Execute(char.Parse(Kelime.Substring(Kelime.Length - 1, 1)), "SERT_ÜNSÜZ"))
                    {
                        #region Kelimenin Düşme Özel Durumu Varsa

                        if (SesOlayları.DüşmeÖzelDurum.DüşmeKontrol(Kelime))
                        {
                            // Kelime düşme özel durumuna sahip  ise yumuşamaya uğramadan ek dizesi işleniyor.
                            Kontrol_Harfi = Kelime.Substring(Kelime.Length - 2, 1);
                            Kelime = Kelime.Remove(Kelime.Length - 2, 1);

                            for (int i = 0; i < EkDizisi.Length; i++)
                            {
                                if (Kontrol.Execute(char.Parse(Kontrol_Harfi), EkDizisi[i].Split('-')[1]))
                                    Kelime += EkDizisi[i].Split('-')[0];

                            }
                        }

                        #endregion




                        #region Yumusama Özel Durumu Kontrol
                        else
                        {
                            // Kelime yumuşama özel durumuna sahip ise Yumusatıcı() metodu ile kelimenin sonundaki sert ünsüz yumuşatılıyor.
                            if (SesOlayları.YumuşamaÖzelDurum.execute(char.Parse(Kelime.Substring(Kelime.Length - 1, 1)), Kelime))
                            {
                                Kelime = SesOlayları.Yumusama.Yumusatıcı(Kelime);
                            }

                            #endregion
                            for (z = Kelime.Length - 1; z >= 0; z--)
                            {

                                for (i = 0; i < EkDizisi.Length; i++)
                                {
                                    if (Kontrol.Execute(char.Parse(Kelime.Substring(z, 1)), EkDizisi[i].Split('-')[1]))
                                    {
                                        Kelime += EkDizisi[i].Split('-')[0];
                                        goto end;
                                    }
                                }

                            }

                        }

                    }

                    #endregion

                    #region Kelimenin Son Harfi Ünsüz İse
                    else
                    {
                        if (SesOlayları.DüşmeÖzelDurum.DüşmeKontrol(Kelime))
                        {
                            Kontrol_Harfi = Kelime.Substring(Kelime.Length - 2, 1);
                            Kelime = Kelime.Remove(Kelime.Length - 2, 1);

                            for ( i = 0; i < EkDizisi.Length; i++)
                            {
                                if (Kontrol.Execute(char.Parse(Kontrol_Harfi), EkDizisi[i].Split('-')[1]))
                                    Kelime += EkDizisi[i].Split('-')[0];

                            }
                        }

                        else

                        {
                           
                                for ( z = Kelime.Length - 1; z >= 0; z--)
                            {

                                for (i = 0; i < EkDizisi.Length; i++)
                                {
                                    if (Kontrol.Execute(char.Parse(Kelime.Substring(z, 1)), EkDizisi[i].Split('-')[1]))
                                    {
                                        Kelime += EkDizisi[i].Split('-')[0];
                                        goto end;
                                    }
                                }

                            }
                            
                        }
                    }
                    #endregion
                }
                #endregion

                else
                {
                    throw new TanımlanamayanEkTürü(EkTürü);
                }
            }

            end:

            return Kelime;
       }
   
    }
}
