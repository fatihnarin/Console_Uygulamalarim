using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarfliNotHesaplama
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Not Hesaplama Programına Hoş Geldiniz");
            Console.WriteLine("*************************************");
            int sec = 0;


            while (sec != 2)
            {
                bassec:
                Console.WriteLine("1: Not Hesaplama programına giriş");
                Console.WriteLine("2: Programdan çıkış");


                try
                {
                    sec = Convert.ToInt16(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Geçerli bir değer girin");
                    goto bassec;
                }
                if (sec > 2 || sec < 1)
                {
                    Console.WriteLine("Geçerli bir değer girin");
                    goto bassec;
                }
                if (sec == 2)
                {
                    Console.WriteLine("güle güle");
                    goto son;
                }
                puanhesaplama();

            }
            son:

            Console.ReadKey();
        }

        private static void puanhesaplama()
        {
            int vize = 0;
            int final = 0;
            basadön:
            try
            {
                Console.WriteLine("Lütfen Vize Notunuzu Giriniz (0-100)");
                vize = Convert.ToInt16(Console.ReadLine());
            }
            catch (Exception)
            {

                Console.WriteLine("Lütfen geçerli bir not giriniz");
                goto basadön;
            }
            if (vize < 0 || vize > 100)
            {
                Console.WriteLine("Lütfen geçerli bir not giriniz");
                goto basadön;
            }
            fbasadön:
            try
            {
                Console.WriteLine("Lütfen Final Notunuzu Giriniz (0-100)");
                final = Convert.ToInt16(Console.ReadLine());
            }
            catch (Exception)
            {

                Console.WriteLine("Lütfen geçerli bir not giriniz");
                goto fbasadön;
            }
            if (final < 0 || final > 100)
            {
                Console.WriteLine("Lütfen geçerli bir not giriniz");
                goto fbasadön;
            }

            double ortalama = (0.4 * vize) + (0.6 * final);

            if (ortalama < 50)
            {
                Console.WriteLine("Ortalamanız "+ortalama+" FF kaldınız");
            }
            else if (ortalama < 60)
            {
                Console.WriteLine("Ortalamanız " + ortalama + " DD : orta-zayıf");
            }
            else if (ortalama < 70)
            {
                Console.WriteLine("Ortalamanız " + ortalama + " CC : orta");
            }
            else if (ortalama < 80)
            {
                Console.WriteLine("Ortalamanız " + ortalama + " BB : yüksek-orta");
            }
            else
            {
                Console.WriteLine("Ortalamanız " + ortalama + " AA : yüksek");
            }
        }

    }
}

