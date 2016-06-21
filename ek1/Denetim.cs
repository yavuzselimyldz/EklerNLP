using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using net.zemberek.yapi;

namespace ek1
{
   public class Denetim
    {
        #region Değişkenler
        private static string silinen = string.Empty;
        private static string yeni_düzelt;
        private static string yeni = string.Empty;
        private static string yedek = string.Empty;
        private static string sonuc = string.Empty;
        private static bool flag;
        private static int i;
        private static char[] karakter;
        #endregion

        // ***************************************** EKLER_TR *************************************************************

        public static string Düzelt(string veri)
        {
            sonuc = "";

        

            if (veri.Length != 0)
            {
                karakter = veri.ToCharArray();
                for (i = 0; i < veri.Length; i++)
                {
                    if (!char.IsControl(karakter[i]) && !char.IsLetter(karakter[i]) && (karakter[i] != ' '))
                    {
                        sonuc = veri;
                        goto end;
                    }
                }

                sonuc = SertEk_Düzelt(veri.ToLower());

                sonuc = Yumusama_Ters_Düzelt(sonuc);

                sonuc = Yumusama_Düzelt(sonuc);

                sonuc = Ek_Düzelt(sonuc);

                sonuc = Düşme_Düzelt(sonuc);
            }
            end:
            return sonuc;
        }
        public static string Ek_Düzelt(string veri)
        {

            if (!Zemberek_Aracı.Turkce_Denetle(veri))
            {

                if (Zemberek_Aracı.Kelime_Öner(veri) == veri)
                {
                    silinen += veri.Substring(veri.Length - 1, 1);
                    veri = veri.Remove(veri.Length - 1, 1);
                    Ek_Düzelt(veri);
                }

                else

                {
                    char[] harfler = silinen.ToCharArray();
                    Array.Reverse(harfler);
                    silinen = new string(harfler);


                    yeni_düzelt = Zemberek_Aracı.Kelime_Öner(veri) + silinen;
                    silinen = "";

                    if (yeni_düzelt.Length >= 2 && veri.Length >= 2)
                    {
                        if (yeni_düzelt.Substring(0, 2) != veri.Substring(0, 2))
                            yeni_düzelt = veri;
                    }


                }
            }
            else
                yeni_düzelt = veri;
            
            return yeni_düzelt;

           
        }
        public static string Kök_Bul(string veri)
        {
             yedek = veri;
            
            x:
                try
                {

                    yedek = Zemberek_Aracı.cozumleyici(yedek)[0].kok().icerik();
                }

                catch (Exception e2)
                {

                if (yedek.Length != 0)
                {
                    yedek = yedek.Remove(yedek.Length - 1, 1);
                    goto x;
                }


                 }



            if (!Zemberek_Aracı.Turkce_Denetle(yedek))
                yedek = veri;

            return yedek;



        }
        public static string Yumusama_Düzelt(string veri)
        {
             string yeni="";

            if (Kontrol.Kontrol_sertünsüz(char.Parse(Denetim.Kök_Bul(veri).Substring(Denetim.Kök_Bul(veri).Length - 1, 1))))
            {
                if (Denetim.Kök_Bul(veri) != veri && SesOlayları.YumuşamaÖzelDurum.execute(char.Parse(Denetim.Kök_Bul(veri).Substring(Denetim.Kök_Bul(veri).Length-1,1)),Denetim.Kök_Bul(veri)))
                {
                    if (Kontrol.Kontrol_ünlüharf(char.Parse(veri.Substring(Denetim.Kök_Bul(veri).Length , 1))))
                        yeni = SesOlayları.Yumusama.Yumusatıcı(Denetim.Kök_Bul(veri)) + veri.Substring(Denetim.Kök_Bul(veri).Length);
                    else
                        yeni = veri;
                }
                else
                    yeni = veri;
            }

            else
                yeni = veri;


            return yeni;

        }
        public static string Yumusama_Ters_Düzelt(string veri)
        {
             flag = false;
            yedek = veri;
            if (!Zemberek_Aracı.Turkce_Denetle(veri))
            {
                while (flag == false)
                {
                    for ( i = 0; i < veri.Length-1; i++)
                    {
                        if (Kontrol.Kontrol_yumusakünsüz(veri[i]))
                        {
                            yedek = veri.Replace(veri[i], SesOlayları.Yumusama.Sertleştirici(veri[i]));
                            if (Zemberek_Aracı.Turkce_Denetle(Denetim.Kök_Bul(yedek)))
                            {
                                if (!Kontrol.Kontrol_ünlüharf(veri[i + 1]))
                                    veri = Denetim.Kök_Bul(yedek) + veri.Substring(i + 1);

                                flag = true;

                            }
                            flag = true;
                        }
                        flag = true;
                    }
                    flag = true;
                }
            }

            return veri;
        }
        public static string Düşme_Düzelt(string veri)
        {
            yeni = veri;
            if (veri.Length != Denetim.Kök_Bul(veri).Length)
            {
                if (SesOlayları.DüşmeÖzelDurum.DüşmeKontrol(Kök_Bul(veri)) && Kontrol.Kontrol_ünlüharf(char.Parse(veri.Substring(Denetim.Kök_Bul(veri).Length, 1))))
                {

                    yeni = Kök_Bul(veri).Remove(Kök_Bul(veri).Length - 2, 1) + veri.Substring(Kök_Bul(veri).Length);

                }
            }
            return yeni;

        }
        public static string SertEk_Düzelt(string veri)
        {
            yeni = "";
            if (Kontrol.Kontrol_fıstıkcısahap(char.Parse(Denetim.Kök_Bul(veri).Substring(Denetim.Kök_Bul(veri).Length - 1, 1))))
            {
                if (veri.Length > Denetim.Kök_Bul(veri).Length +1)
                {
                    if (veri.Substring(Denetim.Kök_Bul(veri).Length, 2) == "de" || veri.Substring(Denetim.Kök_Bul(veri).Length, 2) == "da")
                        yeni = Denetim.Kök_Bul(veri) + SesOlayları.Yumusama.DiziSertleştirici(veri.Substring(Denetim.Kök_Bul(veri).Length));
                    else
                        yeni = veri;
                }
                else
                    yeni = veri;
                
            }
            else
                yeni = veri;


            return yeni;

        }
    }
}

