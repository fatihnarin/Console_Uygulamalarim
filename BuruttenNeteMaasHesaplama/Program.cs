using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuruttenNeteMaasHesaplama
{
    class Program
    {
        static void Main(string[] args)
        {
            //Yıllık 50000TL' ye kadar %15 Vergi
            //50000TL- 100000TL arası %20 Vergi
            // 100000TL üstü %30 Vergi

            Console.WriteLine("Maaş Hesaplama programına hoş geldiniz");
            Console.WriteLine("*************************************");
            int sec = 0;
            while (sec != 2)
            {
                bassec:
                Console.WriteLine("1: Maaş  Hesaplama programına giriş");
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
                BuruttenNeteMaasHesaplama();
            }
            son:
            Console.ReadKey();
        }

        private static void BuruttenNeteMaasHesaplama()
        {
            double maas = 0;

            basadön:
            try
            {
                Console.WriteLine("Aylık bürüt maaşınızı giriniz");
                maas = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {

                Console.WriteLine("Lütfen geçerli bir değer girin");
                goto basadön;
            }
            if (maas < 0)
            {
                Console.WriteLine("Lütfen geçerli bir değer girin");
                goto basadön;
            }

            double yillikmaas = 12 * maas;
            if (yillikmaas <= 50000)
            {
                double yilliknetmaas = yillikmaas * 0.85;
                double yillikvergi = yillikmaas * 0.15;
                Console.WriteLine("Yıllık toplam maaş=" + yillikmaas + "  yıllık toplam net maas =" + yilliknetmaas + "yıllık vergi =" + yillikvergi);
            }
            else if (yillikmaas <= 100000)
            {
                double yilliknetmaas = ((yillikmaas - 50000) * 0.8) + 42500;
                double yillikvergi = ((yillikmaas - 50000) * 0.2) + 7500;
                Console.WriteLine("Yıllık toplam maaş=" + yillikmaas + "  yıllık toplam net maas =" + yilliknetmaas + "yıllık vergi =" + yillikvergi);
            }
            else
            {
                double yilliknetmaas = ((yillikmaas - 100000) * 0.7) + 82500;
                double yillikvergi = ((yillikmaas - 100000) * 0.3) + 17500;
                Console.WriteLine("Yıllık toplam maaş=" + yillikmaas + "  yıllık toplam net maas =" + yilliknetmaas + "yıllık vergi =" + yillikvergi);
            }
        }
    }
}