using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasKagitMakasOyunu
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Taş Kağıt Makas oyununa hoş geldiniz ");
            Console.WriteLine("*************************************");
            int sec = 0;
            int bilgisayar = 0;
            int oyuncu = 0;
            int berabere = 0;
            while (sec != 4)
            {
                basadön:
                MenuOlustur();
                try
                {
                    sec = Convert.ToInt16(Console.ReadLine());
                    Random Tut = new Random();
                    int tutulan = Tut.Next(1, 4);

                    switch (sec)
                    {
                        case 1:
                            if (tutulan == 1)
                            {
                                Console.WriteLine("Berabere, Bigisayar taş");
                                berabere++;
                            }
                            else if (tutulan == 2)
                            {
                                Console.WriteLine("Bilgisayar kağıt, kazanan bilgisayar");
                                bilgisayar++;
                            }
                            else
                            {
                                Console.WriteLine("Bilgisayar makas, kazanan oyuncu");
                                oyuncu++;
                            }

                            break;
                        case 2:
                            if (tutulan == 1)
                            {
                                Console.WriteLine("Bilgisayar taş, kazanan oyuncu");
                                oyuncu++;
                            }
                            else if (tutulan == 2)
                            {
                                Console.WriteLine("Bilgisayar kağıt, berabere");
                                berabere++;
                            }
                            else
                            {
                                Console.WriteLine("Bilgisayar taş, kazanan Bilgisayar");
                                bilgisayar++;
                            }
                            break;


                        case 3:
                            if (tutulan == 1)
                            {
                                Console.WriteLine("Bilgisayar taş, kazanan Bilgisayar");
                                bilgisayar++;
                            }
                            else if (tutulan == 2)
                            {
                                Console.WriteLine("Bilgisayar kağıt, kazanan oyuncu");
                                oyuncu++;
                            }
                            else
                            {
                                Console.WriteLine("Bilgisayar makas, berabere ");
                                berabere++;
                            }
                            break;
                        case 4:
                            break;
                        default:
                            Console.WriteLine("Geçersiz işlem lütfen menüdekilerden birini seçiniz ");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Geçersiz işlem lütfen menüdekilerden birini seçiniz ");
                    goto basadön;

                }


               
            }
            Console.WriteLine("Sonuç --> Oyuncu =" + oyuncu + "  Bilgisayar =" + bilgisayar + "  Berabere =" + berabere);
            Console.ReadKey();
        }

        private static void MenuOlustur()
        {

            Console.WriteLine("Taş için 1' e seçin");
            Console.WriteLine("Kağıt için 2'yi seçin");
            Console.WriteLine("Makas için 3'ü seçin");
            Console.WriteLine("Çıkmak için 4'ü seçin");
            Console.WriteLine("İşlem Seçiniz");

        }


    }
}
