using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IciceMetotlarileDortIslem
{
    class Program
    {
        static void Main(string[] args)
        {         
            MenuOlustur();
            Console.ReadKey();
        }
        private static void MenuOlustur()
        {
            basadon:
            try
            {
                Console.WriteLine("1. Sayıyı Giriniz");
                double Sayi1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("2. Sayıyı Giriniz");
                double Sayi2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Menu");
                Console.WriteLine("1- Topla");
                Console.WriteLine("2- Çarp");
                Console.WriteLine("3- Böl");
                Console.WriteLine("4- Çıkar");
                Console.WriteLine("İşlem Seçiniz");
                int Sec = Convert.ToInt16(Console.ReadLine());
                secilenislem(Sec, Sayi1, Sayi2);
            }
            catch (Exception)
            {

                Console.WriteLine("Hatali işlem ");
                goto basadon;
            }
            

        }

        private static void secilenislem(int sec, double s1, double s2)
        {
            switch (sec)
            {
                case 1:
                    double Sonuc = topla(s1, s2);
                    Console.WriteLine(s1 + "+" + s2 + "=" + Sonuc);
                    devammi();
                    break;
                case 2:
                    // Sonuç Dönmeyecek ...
                    carpma(s1, s2);
                    devammi();                   
                    break;
                case 3:
                    if (s2 == 0)
                    {
                        Console.WriteLine("Bölen sayı 0 olamaz!!");
                        MenuOlustur();
                    }
                    else
                    {
                        Sonuc = bol(s1, s2);
                        Console.WriteLine(s1 + "/" + s2 + "=" + Sonuc);
                        devammi();
                    }                                        
                    break;
                case 4:
                    cikar(s1,s2);
                    devammi();
                    break;
                default:
                    MenuOlustur();
                    break;
            }
        }
        public static double topla(double s1, double s2)
        {
            double son = s1 + s2;
            return (son);

        }
        private static void carpma(double sayi1, double sayi2)
        {
            Console.WriteLine(sayi1 + "*" + sayi2 + "=" + sayi1 * sayi2);
        }
        private static double bol(double s1, double s2)
        {           
            return (s1/s2);            
        }
        private static void cikar(double sayi1, double sayi2)
        {
            Console.WriteLine(sayi1 + "-" + sayi2 + "=" + (sayi1 - sayi2));
        }
        private static void devammi()
        {
            Console.WriteLine("Tekrar Etmek İster misiniz ? (E/H)");
            string EH = Console.ReadLine();
            if (EH == "E" || EH == "e")
            {
                MenuOlustur();

            }
            else
            {
                Console.WriteLine("Teşekkürler ...");
            }
        }
    }
}
