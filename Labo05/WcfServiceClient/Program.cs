using System;
using WcfServiceClient.ServiceReference1;

namespace WcfServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Krok 1: Utworzenie instancji WCF proxy.
            // KalkulatorClient mojKlient = new KalkulatorClient();

            SpaceXClient klient1 = new SpaceXClient("WSHttpBinding_ISpaceX");
            SpaceXClient klient2 = new SpaceXClient("BasicHttpBinding_ISpaceX");
            SpaceXClient klient3 = new SpaceXClient("mojEndpoint3");

            // Krok 2: Wywolanie operacji uslugi.
            Console.WriteLine("Klient 1: ");
            Console.WriteLine($"Pobierz informacje o firmie: ");
            var result = klient1.GetCompanyInfo();
            Console.WriteLine(result);
            Console.Write($"Wywołaj metode odejmowania dwóch liczb: ");
            result = klient1.GetLaunches();
            Console.WriteLine(result);
            klient1.Close();

            /* Console.Write($"Wywołaj metode mnożenia dwóch liczb: ");
             result = klient1.Pomnoz(3, 6);
             Console.WriteLine(result);
             Console.Write($"Wywołaj metode sumowanie: ");
             klient1.Sumuj(1);
             result = klient1.Sumuj(11);
             Console.WriteLine(result);
             klient1.Close();

             Console.WriteLine("Klient 2: ");
             Console.Write($"Wywołaj metode dodawania dwóch liczb: ");
             result = klient2.Dodaj(2, 3);
             Console.WriteLine(result);
             Console.Write($"Wywołaj metode odejmowania dwóch liczb: ");
             result = klient2.Odejmij(6, 3);
             Console.WriteLine(result);
             Console.Write($"Wywołaj metode mnożenia dwóch liczb: ");
             result = klient2.Pomnoz(3, 6);
             Console.WriteLine(result);
             Console.Write($"Wywołaj metode sumowanie: ");
             klient2.Sumuj(2);
             result = klient2.Sumuj(1);
             Console.WriteLine(result);
             klient2.Close();

             Console.WriteLine("Klient 3: ");
             Console.Write($"Wywołaj metode dodawania dwóch liczb: ");
             result = klient3.Dodaj(2, 3);
             Console.WriteLine(result);
             Console.Write($"Wywołaj metode odejmowania dwóch liczb: ");
             result = klient3.Odejmij(6, 3);
             Console.WriteLine(result);
             Console.Write($"Wywołaj metode mnożenia dwóch liczb: ");
             result = klient3.Pomnoz(3, 6);
             Console.WriteLine(result);
             Console.Write($"Wywołaj metode sumowanie: ");
             klient3.Sumuj(8);
             result = klient3.Sumuj(15);
             Console.WriteLine(result);
             klient3.Close();*/
        }
    }
}
