using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ek1
{
    public static class Kontrol
    {
        private static bool flag;
        // Her kontrol metodu içerisine harf verisi gönderilerek harfin ilgili koşula uyup uymadığı switch-case ler ile denetlenir.

        public static bool Execute(char c,string tip)
        {
            // Ana kontrol metodu tercihe göre kullanılabilir.
            flag = false;
            switch (tip)
            {
                case "ÜNLÜ_HARF":
                    flag = Kontrol_ünlüharf(c);
                    break;
                case "İNCE_ÜNLÜ":
                    flag = Kontrol_inceünlü(c);
                    break;
                case "KALIN_ÜNLÜ":
                    flag = Kontrol_kalınünlü(c);
                    break;
                case "KALIN_DÜZ_ÜNLÜ":
                    flag = Kontrol_kalındüzünlü(c);
                    break;
                case "İNCE_DÜZ_ÜNLÜ":
                    flag = Kontrol_inceüdüzünlü(c);
                    break;
                case "KALIN_YUVARLAK_ÜNLÜ":
                    flag = Kontrol_kalınyuvarlakünlü(c);
                    break;
                case "İNCE_YUVARLAK_ÜNLÜ":
                    flag = Kontrol_inceyuvarlakünlü(c);
                    break;
                case "FISTIKÇI_ŞAHAP":
                    flag = Kontrol_fıstıkcısahap(c);
                    break;
                case "SERT_ÜNSÜZ":
                    flag = Kontrol_sertünsüz(c);
                    break;
                default:

                    break;   
             
            }

            return flag;


        }

        // Rakamları okunuşlarına karşılık gelen string ifadelere dönüştürmek için kullanılır.
        public static string Kontrol_Rakam_Dönüstür(string c)
        {

            switch (c)
            {
                case "0":
                    c = "sıfır";
                    break;
                case "1":
                    c = "bir";
                    break;
                case "2":
                    c = "iki";
                    break;
                case "3":
                    c = "üç";
                    break;
                case "4":
                    c = "dört";
                    break;
                case "5":
                    c = "beş";
                    break;
                case "6":
                    c = "altı";
                    break;
                case "7":
                    c = "yedi";
                    break;
                case "8":
                    c = "sekiz";
                    break;
                case "9":
                    c = "dokuz";
                    break;
                default:

                    break;
            }
            return c;
        }

        #region Rakam Mı?
        public static bool Kontrol_Rakam(char c)
        { 
        flag = false;
            switch (c)
            {
                case '0':
                    flag = true;
                    break;
                case '1':
                    flag = true;
                    break;
                case '2':
                    flag = true;
                    break;
                case '3':
                    flag = true;
                    break;
                case '4':
                    flag = true;
                    break;
                case '5':
                    flag = true;
                    break;
                case '6':
                    flag = true;
                    break;
                case '7':
                    flag = true;
                    break;
                case '8':
                    flag = true;
                    break;
                case '9':
                    flag = true;
                    break;
                default:

                    break;

            }
            return flag;
        }

#endregion

        #region  Harf Ünlü Mü?

public static bool Kontrol_ünlüharf(char c)
        {
             flag = false;
            switch (c)
            {
                case 'a':
                    flag = true;
                    break;
                case 'e':
                    flag = true;
                    break;
                case 'ı':
                    flag = true;
                    break;
                case 'i':
                    flag = true;
                    break;
                case 'o':
                    flag = true;
                    break;
                case 'ö':
                    flag = true;
                    break;
                case 'u':
                    flag = true;
                    break;
                case 'ü':
                    flag = true;
                    break;
                default:

                    break;

            }
            return flag;
        }

        #endregion

        #region  Harf İnce Ünlü Mü?

        public static bool Kontrol_inceünlü(char c)
        {
             flag = false;
            switch (c)
            {
                case 'e':
                    flag = true;
                    break;
                case 'i':
                    flag = true;
                    break;
                case 'ö':
                    flag = true;
                    break;
                case 'ü':
                    flag = true;
                    break;
               
                default:

                    break;

            }
            return flag;

        }

        #endregion

        #region Harf Kalın Ünlü Mü?

        public static bool Kontrol_kalınünlü(char c)
        {
            flag = false;
            switch (c)
            {
                case 'a':
                    flag = true;
                    break;
                case 'ı':
                    flag = true;
                    break;
                case 'o':
                    flag = true;
                    break;
                case 'u':
                    flag = true;
                    break;

                default:

                    break;

            }
            return flag;

        }

        #endregion

        #region Harf Kalın Düz Ünlü Mü?

        public static bool Kontrol_kalındüzünlü(char c)
        {
            flag = false;
            switch (c)
            {
                case 'a':
                    flag = true;
                    break;
                case 'ı':
                    flag = true;
                    break;
                default:

                    break;
            }
            return flag;

        }

        #endregion

        #region Harf İnce Düz Ünlü Mü?

        public static bool Kontrol_inceüdüzünlü(char c)
        {

             flag = false;
            switch (c)
            {
                case 'e':
                    flag = true;
                    break;
                case 'i':
                    flag = true;
                    break;
                default:

                    break;
            }
            return flag;

        }

        #endregion

        #region Harf Kalın Yuvarlak Ünlü Mü?

        public static bool Kontrol_kalınyuvarlakünlü(char c)
        {
            flag = false;
            switch (c)
            {
                case 'o':
                    flag = true;
                    break;
                case 'u':
                    flag = true;
                    break;
                default:

                    break;
            }
            return flag;

        }

        #endregion

        #region Harf İnce Yuvarlak Ünlü Mü?

        public static bool Kontrol_inceyuvarlakünlü(char c)
        {
            flag = false;
            switch (c)
            {
                case 'ö':
                    flag = true;
                    break;
                case 'ü':
                    flag = true;
                    break;
                default:

                    break;
            }
            return flag;

        }

        #endregion

        #region Fıstıkçı Şahap

        public static bool Kontrol_fıstıkcısahap(char c)
        {
            flag = false;
            switch (c)
            {
                case 'f':
                    flag = true;
                    break;
                case 's':
                    flag = true;
                    break;
                case 't':
                    flag = true;
                    break;
                case 'k':
                    flag = true;
                    break;
                case 'ç':
                    flag = true;
                    break;
                case 'ş':
                    flag = true;
                    break;
                case 'h':
                    flag = true;
                    break;
                case 'p':
                    flag = true;
                    break;
                default:

                    break;

            }
            return flag;



        }

        #endregion

        #region Harf Sert Ünsüz Mü?

        public static bool Kontrol_sertünsüz(char c)
        {
            bool flag = false;

            switch (c)
            {
                case 'p':
                    flag = true;
                    break;
                case 'ç':
                    flag = true;
                    break;
                case 't':
                    flag = true;
                    break;
                case 'k':
                    flag = true;
                    break;
                default:

                    break;

            }



            return flag;
        }

        #endregion

        #region Harf Yumusak Ünsüz Mü?

        public static bool Kontrol_yumusakünsüz(char c)
        {
            flag = false;

            switch (c)
            {
                case 'b':
                    flag = true;
                    break;
                case 'c':
                    flag = true;
                    break;
                case 'd':
                    flag = true;
                    break;
                case 'g':
                    flag = true;
                    break;
                default:

                    break;

            }



            return flag;
        }

        #endregion
    }
}
