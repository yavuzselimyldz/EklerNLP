using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ek1
{
    public static class SesOlayları
    {
        private static bool flag;
        private static string yeni = string.Empty; 

        public class Yumusama : ISesOlayları 
        {
            

            public static string Yumusatıcı(string Kelime)
            {

               
                switch (Kelime.Substring(Kelime.Length - 1, 1))
                {
                    // Gönderilen kelime verisinin son harfi yumuşatılır.
                    case "p":
                        if (!SesOlayları.YumuşamaÖzelDurum.P_biten_Yumusamayan(Kelime))
                        {
                            Kelime = Kelime.Remove(Kelime.Length - 1, 1);
                            Kelime += "b";
                        }
                        break;
                    case "ç":
                        if (!SesOlayları.YumuşamaÖzelDurum.Ç_biten_Yumusamayan(Kelime))
                        {
                            Kelime = Kelime.Remove(Kelime.Length - 1, 1);
                            Kelime += "c";

                        }
                        break;
                    case "t":
                        if (SesOlayları.YumuşamaÖzelDurum.T_biten_Yumusayan(Kelime))
                        {
                            Kelime = Kelime.Remove(Kelime.Length - 1, 1);
                            Kelime += "d";
                        }

                        break;

                    case "k":
                        if (!SesOlayları.YumuşamaÖzelDurum.K_biten_Yumusamayan(Kelime))
                        {
                            if (Kelime.Substring(Kelime.Length - 2, 1) == "n")
                            {
                                Kelime = Kelime.Remove(Kelime.Length - 1, 1);
                                Kelime += "g";
                            }

                            else
                            {
                                Kelime = Kelime.Remove(Kelime.Length - 1, 1);
                                Kelime += "ğ";
                            }
                        }
                        break;

                    default:
                        break;
                }

                return Kelime;
               

            }

            public static char Sertleştirici(char c)
            {
                // Gönderilen harf verisi sertleştirilir
                switch (c)
                {
                    case 'b':
                        c = 'p';
                        break;

                    case 'c':
                        c = 'ç';
                        break;

                    case 'd':
                        c = 't';
                        break;

                    case 'g':
                        c = 'k';
                        break;

                    case 'ğ':
                        c = 'k';
                        break;

                    default:
                        break;
                }

                return c;


            }

            public static string DiziSertleştirici(string dizi)
            {
                // Benzeşme olayı için kullanılır.Gönderilen ek dizisini sertleştirir.

                yeni = "";
                switch (dizi.Substring(0, 1))
                {
                    case "b":
                        yeni = "p" + dizi.Substring(1, dizi.Length - 1);
                        break;

                    case "c":
                        yeni = "ç" + dizi.Substring(1, dizi.Length - 1);
                        break;

                    case "d":
                        yeni = "t" + dizi.Substring(1, dizi.Length - 1);
                        break;

                    case "g":
                        yeni = "k" + dizi.Substring(1, dizi.Length - 1);
                        break;

                    case "ğ":
                        yeni = "k" + dizi.Substring(1, dizi.Length - 1);
                        break;

                    default:
                        yeni = dizi;
                        break;
                }
                return yeni;
            }


        } 
       
        public class YumuşamaÖzelDurum : ISesOlayları
        {
            #region Kelime Listeleri
      private static string[] sonu_T = new string[] { "ait", "ant", "art", "but", "mucit", "tat", "abat", "açıt", "adet", "ağıt", "amut", "azat", "bant", "bent", "biat", "ceht", "cilt", "dert", "dört", "ebet", "etüt", "fent", "fert", "flüt", "hamt", "icat", "içit", "inat", "irat", "kurt", "kürt", "lort", "mürt", "nezt", "ojit", "öğüt", "stat", "umut", "ümit", "yort", "yurt", "zait", "züht", "ahfat", "ahlat", "akort", "avrat", "avret", "avurt", "ayırt", "bidat", "ceset", "çeşit", "çiğit", "çivit", "ecdat", "evlat", "geçit", "hasat", "hamut", "hudut", "ifrat", "imbat", "imdat", "kağıt", "kanat", "kaset", "katot", "kavat", "kavut", "kenet", "kesat", "kilit", "komot", "komut", "külot", "küvet", "mabat", "mabet", "mabut", "meret", "metot", "milat", "monat", "murat", "mürit", "orkit", "pomat", "raunt", "sadet", "söğüt", "stant", "şerit", "teyit", "tirat", "üstat", "velet", "vücut", "yezit", "yiğit", "cellat", "çiklet", "feryat", "itimat", "kükürt", "maksat", "mescit", "mevcut", "mevlit", "mürşit", "namert", "taklit", "taksit", "takyit", "tecdit", "tecrit", "tecvit", "tehdit", "yoğurt", "züğürt", "zümrüt", "anayurt", "hemdert", "periyot", "piramit", "üçkağıt", "altgeçit", "elektrot", "elipsoit", "helikoit", "hemhudut", "hemoroit", "kalebent", "köşebent", "metaloit", "meteroit", "polaroit", "poliasit", "selüloit", "üstgeçit", "antropoit", "babayiğit", "kırkgeçit", "kızılkurt", "sarıkanat", "yavrukurt", "çakırkanat", "keselikurt", "kızılkanat", "kristaloit", "resmigeçit", "hiperboloit", "kablelmilat", "kancalıkurt", "salkımsöğüt", "tendürdiyot", "terkibibent" };
      private static string[] sonu_P = new string[] { "ip", "alp", "arp", "bap", "cop", "cup", "çap", "çöp", "hap", "hep", "hop", "kep", "kip", "köp", "küp", "lap", "lep", "lüp", "pop", "rap", "rep", "rop", "sap", "sup", "şap", "şıp", "top", "zıp", "acep", "amip", "celp", "kamp", "ramp", "sarp", "turp", "vamp", "kramp", "polip", "çerçöp", "dertop", "ekotip", "estamp", "estomp", "izotop", "şıpşıp", "zıpzıp", "zirzop", "biyotip", "biyotop", "fenotip", "genotip", "monotip", "muakkip", "otostop", "tanktop", "tıpatıp", "uçantop", "yarıçap", "altıntop", "armuttop", "endoskop", "entertip", "handikap", "karaturp", "katakomp", "kızılşap", "partisip", "prototip", "stenotip", "şerefyap", "yalapşap", "yüzertop", "cumburlop", "içyarıçap", "radyoizotop" };
      private static string[] sonu_Ç = new string[] { "aç", "iç", "üç", "hiç", "göç", "kaç", "koç", "maç", "meç", "piç", "pöç", "saç", "seç", "suç", "kırç", "sürç", "vinç", "zevç", "dışgöç", "gelgeç", "merkezkaç" };
      private static string[] sonu_K = new string[] {
"ak",
"ek",
"ok",
"ark",
"aşk",
"bek",
"bok",
"bük",
"cık",
"cuk",
"çek",
"çük",
"dek",
"dik",
"dok",
"dük",
"erk",
"fak",
"foku",
"hık",
"ırk",
"ilk",
"kak",
"kek",
"kik",
"kok",
"kök",
"lak",
"lok",
"lök",
"mok",
"örk",
"pak",
"pik",
"rak",
"rok",
"sak",
"sek",
"sık",
"sik",
"şak",
"şek",
"şık",
"şok",
"tak",
"tek",
"tık",
"tik",
"tok",
"yak",
"yek",
"yok",
"yük",
"afak",
"akak",
"akik",
"apak",
"bank",
"bark",
"berk",
"börk",
"cılk",
"dank",
"delk",
"dink",
"disk",
"fevk",
"fink",
"folk",
"gark",
"görk",
"gurk",
"halk",
"hark",
"herk",
"hınk",
"kask",
"kırk",
"köşk",
"künk",
"kürk",
"mark",
"mask",
"meşk",
"mink",
"misk",
"park",
"punk",
"rızk",
"risk",
"sevk",
"sıdk",
"sirk",
"şark",
"şavk",
"şirk",
"talk",
"türk",
"zamk",
"zerk",
"zevk",
"zınk",
"ahlak",
"ayyuk",
"hukuk",
"merak",
"misak",
"nifak",
"özerk",
"ramak",
"revak",
"alakok",
"anakök",
"bombok",
"fiyonk",
"hepyek",
"menisk",
"meşkük",
"müştak",
"römork",
"sağbek",
"seksek",
"şeşyek",
"şipşak",
"tahkik",
"tasdik",
"tatbik",
"tetkik",
"vesaik",
"yaderk",
"ağırşak",
"arabesk",
"arşidük",
"fototek",
"göktürk",
"grandük",
"grotesk",
"guguruk",
"gülbank",
"halayık",
"iltisak",
"infilak",
"irtifak",
"iştikak",
"iştiyak",
"iştirak",
"ittifak",
"karekök",
"mutabık",
"muvafık",
"münafık",
"müsabık",
"obelisk",
"otopark",
"peçvörk",
"pirüpak",
"pleybek",
"taalluk",
"tetabuk",
"tevafuk",
"dökmeyük",
"ehlizevk",
"ekinokok",
"eklektik",
"istiğrak",
"istihkak",
"istihlak",
"kartotek",
"katafalk",
"lunapark",
"mikrokok",
"müstahak",
"pitoresk",
"romanesk",
"saçakkök",
"sofistik",
"taberrük",
"tahakkuk",
"tefevvuk",
"temellük",
"tıngadak",
"yaldırak",
"zıngadak",
"zıppadak",
"antarktik",
"ciharıyek",
"devremülk",
"kırkmerak",
"nişaburek",
"paleozoik",
"prefabrik",
"rengarenk"


 };
            #endregion


            private static int i;

            // Listeler içerisindeki verilere göre denetleme yapılarak Kelime verisinin yumusama özel durumuna sahip olup olmadığı denetleniyor. 

        public static bool T_biten_Yumusayan(string Kelime)
        {
             flag = false;

            

            #region Kontrol Döngüsü
            for ( i = 0; i < sonu_T.Length; i++)
            {
                if (Kelime == sonu_T[i])
                {
                    flag = true;
                }
            }
            #endregion

            return flag;

          

        }

        public static bool P_biten_Yumusamayan(string Kelime)
        {
            flag = false;


            #region Kontrol Döngüsü
            for ( i=0; i < sonu_P.Length;i++)
            {
                if (Kelime==sonu_P[i])
                {

                    flag = true;

                }
            }
            #endregion

            return flag;
        }

        public static bool Ç_biten_Yumusamayan(string Kelime)
        {
             flag = false;

           

            #region Kontrol Döngüsü
            for (i = 0; i < sonu_Ç.Length; i++)
            {
                if (Kelime == sonu_Ç[i])
                {

                    flag = true;

                }
            }
            #endregion

            return flag;


        }

        public static bool  K_biten_Yumusamayan(string Kelime)
        {

             flag = false;


            #region Kontrol Döngüsü
            for ( i = 0; i < sonu_K.Length; i++)
            {
                if (Kelime == sonu_K[i])
                {

                    flag = true;

                }
            }
            #endregion

            return flag;



        }

        public static bool execute(char c, string Kelime)
        {
             flag = false;

            switch (c)
            {
                case 't':
                    if (T_biten_Yumusayan(Kelime))
                        flag = true;
                    break;
                case 'p':
                    if (!P_biten_Yumusamayan(Kelime))
                        flag = true;
                    break;
                case 'ç':
                    if (!Ç_biten_Yumusamayan(Kelime))
                        flag = true;
                    break;
                case 'k':
                    if (!K_biten_Yumusamayan(Kelime))
                        flag = true;

                    break;

                default:
                    break;


            }

            return flag;
        }
        }

        public class DüşmeÖzelDurum : ISesOlayları
        {
            #region Kelime Listesi
        private static string[] Düşenler = new string[] {
"ağız",
"akıl",
"alın",
"ayır",
"bağır",
"beniz",
"beyin",
"boyun",
"böğür",
"burun",
"cisim",
"cürüm",
"çağır",
"çevir",
"devir",
"fikir",
"geniz",
"göğüs",
"gönül",
"hapis",
"hüküm",
"isim",
"karın",
"kahır",
"kayıp",
"kayın",
"kayıt",
"kavur",
"keşif",
"kıvır",
"koyun",
"nakit",
"nesil",
"oğul",
"omuz",
"ömür",
"resim",
"sabır",
"savur",
"sıyır",
"sızı",
"şükür",
"şehir",
"ufuk",
"vakit",
"yalın",
"yanıl",
"zehir",
"zihin",
"zülüf"

 };

            #endregion

            private static int i;

            public static bool DüşmeKontrol(string Kelime)
            {
                // Liste içerisindeki verilere göre denetleme yapılarak Kelime verisinin düşme özel durumuna sahip olup olmadığı denetleniyor. 

                flag = false;

                #region Kontrol Döngüsü
                for ( i = 0; i < Düşenler.Length; i++)
                {
                    if (Kelime == Düşenler[i])
                    {
                        flag = true;
                    }
                }
                #endregion

                return flag;



            }

        }
    }
}
