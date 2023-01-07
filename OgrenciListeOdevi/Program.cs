using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciListeOdevi
{
    class Program
    {
        static void Main(string[] args)
        {
            var ogrnot = new List<ogrencinot>();
            var ogrliste = new List<ogrencilistesi>();
            Console.WriteLine("***************************");
            Console.WriteLine("Öğrenci Not Listesi Programına Hoş Geşdiniz");

            menuolustur(ogrliste, ogrnot);
            Console.ReadKey();
        }

        private static void menuolustur(List<ogrencilistesi> ogrliste, List<ogrencinot> ogrnot)
        {
            int sec = 0;
            while (sec != 6)
            {
            bas:
                Console.WriteLine("**************************");
                Console.WriteLine("**********MENÜ************");
                Console.WriteLine("1: Öğrenci Giriş");
                Console.WriteLine("2: Sınav Girşi");
                Console.WriteLine("3: Öğrenci Listesi");
                Console.WriteLine("4: Öğrenci Sınav Listesi");
                Console.WriteLine("5: Sınav Notu Değiştirme");
                Console.WriteLine("6: EXİT--ÇIKIŞ");
                Console.WriteLine("**************************");
                Console.WriteLine("Lütfen seçiminizi yapın");
                try
                {
                    sec = Convert.ToInt16(Console.ReadLine());
                    if (sec < 1 || sec > 6)
                    {
                        Console.WriteLine("Hatalı seçim lütfen menüden seçim yapın");
                        goto bas;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Hatalı seçim lütfen menüden seçim yapın");
                    goto bas;
                }
                switch (sec)
                {
                    case 1:
                        ogrencigiris(ogrliste, ogrnot);
                        break;
                    case 2:
                        sınavgiris(ogrliste, ogrnot);
                        break;
                    case 3:
                        ogrencilistesimetot(ogrliste);
                        break;
                    case 4:
                        ogrencisinavlistesi(ogrliste, ogrnot);
                        break;
                    case 5:
                        sinavnotudegistirme(ogrliste, ogrnot);
                        break;
                    case 6:
                        break;
                }
            }
        }

        private static void sinavnotudegistirme(List<ogrencilistesi> ogrliste, List<ogrencinot> ogrnot)
        {
            if (ogrnot.Count == 0)
            {
                Console.WriteLine("Liste Boş !!! ");
                menuolustur(ogrliste, ogrnot);
            }
            else
            {
                string tc = tcKontrol();
                for (int i = 0; i < ogrnot.Count; i++)
                {
                    if (ogrnot[i].TC == tc)
                    {
                        ogrnot.Remove(ogrnot[i]);
                        Console.WriteLine(tc + "TC kimlik numaları kayıt silindi.");
                        Console.WriteLine("Tekrar kayıt yapın");
                        sınavgiris(ogrliste, ogrnot);
                    }
                    else
                    {
                        Console.WriteLine(tc + "  numaralı kimlik numarası bulunamadı ");
                        menuolustur(ogrliste, ogrnot);
                    }
                }
            }
        }

        private static void ogrencisinavlistesi(List<ogrencilistesi> ogrliste, List<ogrencinot> ogrnot)
        {
            if (ogrnot.Count == 0)
            {
                Console.WriteLine("Liste Boş ");
                menuolustur(ogrliste, ogrnot);
            }
            else
            {
                foreach (var item in ogrliste)
                {
                    foreach (var item1 in ogrnot)
                    {
                        if (item.TC == item1.TC)
                        {
                            Console.WriteLine("TC:{0} Adı:{1} Soyadı:{2} Vize :{3} Final :{4} Ortalama :{5} Not :{6}", item.TC, item.Adi, item.Soyadi, item1.Vize, item1.Final, item1.Ortalama, item1.Not);
                        }
                    }
                }
            }
        }

        private static void ogrencilistesimetot(List<ogrencilistesi> ogrlistol)
        {
            if (ogrlistol.Count == 0)
            {
                Console.WriteLine("Liste Boş Göstreilecek kimse yok");
            }
            else
            {
                foreach (var item in ogrlistol)
                {
                    Console.WriteLine("TC:{0} Adı:{1} Soyadı:{2}", item.TC, item.Adi, item.Soyadi);
                }
            }
        }
        private static void sınavgiris(List<ogrencilistesi> ogrlist, List<ogrencinot> ogrnt)
        {
            if (ogrlist.Count == 0)
            {
                Console.WriteLine("Öğrenci listesi boş. Önce öğrenci kaytı yapın");
                menuolustur(ogrlist, ogrnt);
            }
            else
            {
                string tc = tcKontrol();
                foreach (var item in ogrnt)
                {
                    if (tc == item.TC)
                    {
                        Console.WriteLine(tc + "TC kimlik numaralı öğrenzinin sınav notları var");
                        Console.WriteLine("Değişiklik yapmak istiyorsanız menüden 5'i seçin");
                        menuolustur(ogrlist, ogrnt);
                    }
                }
                int say = 0;
                int vize = 0;
                int final = 0;
                foreach (var item in ogrlist)
                {
                    if (tc == item.TC)
                    {
                        say = 1;
                    vizedon:

                        Console.WriteLine("Öğrenci Vize notunu girin (0-100):");
                        try
                        {
                            vize = Convert.ToInt16(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Hatalı !!!");
                            goto vizedon;
                        }
                        if (vize < 0 || vize > 100)
                        {
                            Console.WriteLine("Hatalı !!!");
                            goto vizedon;
                        }
                    finaldon:
                        Console.WriteLine("Öğrenci final notunu girin (0-100):");
                        try
                        {
                            final = Convert.ToInt16(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Hatalı !!!");
                            goto finaldon;
                        }
                        if (final < 0 || final > 100)
                        {
                            Console.WriteLine("Hatalı !!!");
                            goto finaldon;
                        }
                    }
                }
                if (say == 0)
                {
                    Console.WriteLine("Girilen TC numarasında öğrenci bulunamadı.");
                    menuolustur(ogrlist, ogrnt);
                }
                double ort = (0.4 * vize + 0.6 * final);
                string not = notHesaplama(ort);
                ogrnt.Add(new ogrencinot() { TC = tc, Vize = vize, Final = final, Ortalama = ort, Not = not });
            }
        }
        private static string notHesaplama(double ort)
        {
            if (ort < 50)
            {
                return "FF";
            }
            else if (ort < 60)
            {
                return "DD";
            }
            else if (ort < 70)
            {
                return "CC";
            }
            else if (ort < 85)
            {
                return "BB";
            }
            else
            {
                return "AA";
            }
        }
        private static void ogrencigiris(List<ogrencilistesi> ogrencilist, List<ogrencinot> ogrnot)
        {
            string tc = tcKontrol();
            foreach (var item in ogrencilist)
            {
                if (tc == item.TC)
                {
                    Console.WriteLine(tc + "TC kimlik numaralı öğrenci zaten kayıtlı !!!");
                    menuolustur(ogrencilist, ogrnot);
                }
            }
            string ad = isimKontrol();
            string soyad = soyAdKontrol();
            ogrencilist.Add(new ogrencilistesi() { TC = tc, Adi = ad, Soyadi = soyad });
        }

        private static string soyAdKontrol()
        {
        soyaddon:
            Console.WriteLine("Öğrenci Soyadı :");
            string soyad = Console.ReadLine();
            int karaktersayisi = soyad.Length;
            if (karaktersayisi < 2)
            {
                Console.WriteLine("Soyad en az 2 halfden oluşur");
                goto soyaddon;
            }
            bool a = HarfMi(soyad);
            if (a != true)
            {
                Console.WriteLine("Soyad harflerden oluşur!!");
                goto soyaddon;
            }
            return soyad;
        }
        private static string isimKontrol()
        {
        addon:
            Console.WriteLine("Öğrenci Adı :");
            string ad = Console.ReadLine();
            int karaktersayisi = ad.Length;
            if (karaktersayisi < 2)
            {
                Console.WriteLine("Ad en az 2 halfden oluşur");
                goto addon;
            }
            bool a = HarfMi(ad);
            if (a != true)
            {
                Console.WriteLine("Ad harflerden oluşur!!");
                goto addon;
            }
            return ad;
        }
        private static string tcKontrol()
        {
        tcdon:
            Console.WriteLine("Öğrenci TC nosunu girin :");
            string tc = Console.ReadLine();
            int karaktersayisi = tc.Length;
            if (karaktersayisi != 11)
            {
                Console.WriteLine("Lütfen TC numarasını 11 haneli giriniz ");
                goto tcdon;
            }
            bool sayimi = SayiMi(tc);
            if (sayimi != true)
            {
                Console.WriteLine("TC numarası sadece rakamlardan oluşmalıdır.");
                goto tcdon;
            }
            return tc;
        }

        private static bool SayiMi(string text)
        {
            foreach (char chr in text)
            {
                if (!Char.IsNumber(chr)) return false;
            }
            return true;
        }
        public static bool HarfMi(string metin)
        {
            bool a = true;
            char[] karakter = metin.ToCharArray();
            for (int i = 0; i < metin.Length; i++)
            {
                if (!char.IsControl(karakter[i]) && !char.IsLetter(karakter[i]) && (karakter[i] != ' '))
                {
                    a = false;
                    return a;
                }
            }
            return a;
        }

        class ogrencinot
        {
            public string TC;
            public int Vize;
            public int Final;
            public double Ortalama;
            public string Not;
        }
        class ogrencilistesi
        {
            public string TC;
            public string Adi;
            public string Soyadi;
        }
    }
}
