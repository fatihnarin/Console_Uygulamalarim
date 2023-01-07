using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkiSayiArasindakiSayilarinToplami
{
    class Program
    {
        static void Main(string[] args)
        {
            basdon:
            try
            {
                Console.WriteLine("1. sayıyı girin :");
                int Baslama = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("2. sayıyı girin :");
                int Bitis = Convert.ToInt16(Console.ReadLine());
                if (Baslama > Bitis)
                {
                    int Sonuc = 0;
                    for (int i = Bitis; i < Baslama; i++)
                    {
                        Console.WriteLine("Sonuç = " +
                                           Sonuc.ToString() +
                                           "+" + i + "= ");
                        Sonuc = Sonuc + i;
                        Console.Write(" " + Sonuc);
                        Console.WriteLine();
                    }
                    Console.WriteLine(Sonuc);
                    Console.WriteLine("Çıkmak için 1'e devam etmek için 2'ye basın");
                    int cikis =Convert.ToInt16(Console.ReadLine());
                    if (cikis==1)
                    {
                        goto son;
                    }
                    else
                    {
                        goto basdon;
                    }
                }
                else
                {
                    int Sonuc = 0;
                    for (int i = Baslama; i < Bitis; i++)
                    {
                        Console.WriteLine("Sonuç = " +
                                           Sonuc.ToString() +
                                           "+" + i + "= ");
                        Sonuc = Sonuc + i;
                        Console.Write(" " + Sonuc);
                        Console.WriteLine();
                    }
                    Console.WriteLine(Sonuc);
                    Console.WriteLine("Çıkmak için 1'e devam etmek için 2'ye basın");
                    int cikis = Convert.ToInt16(Console.ReadLine());
                    if (cikis == 1)
                    {
                        goto son;
                    }
                    else
                    {
                        goto basdon;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Girilen Sayı Değerlerinde Hata Var !");
                Console.WriteLine("Çıkmak için 1'e devam etmek için 2'ye basın");
                int cikis = Convert.ToInt16(Console.ReadLine());
                if (cikis == 1)
                {
                    goto son;
                }
                else
                {
                    goto basdon;
                }
            }
            son:
            Console.ReadKey();
            
        }
    }
}
