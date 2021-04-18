using System;
using WcfServiceClient.ServiceReference1;

namespace WcfServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Krok 1: Utworzenie instancji WCF proxy.

            DbActionClient klient1 = new DbActionClient("WSHttpBinding_IDbAction");
            DbActionClient klient2 = new DbActionClient("BasicHttpBinding_IDbAction");
            DbActionClient klient3 = new DbActionClient("mojEndpoint3");

            // Krok 2: Wywolanie operacji uslugi.
            Console.WriteLine("Klient 1: ");
            Console.WriteLine($"Pobierz informacje o zamówieniach w przedziale 2013 - 2014: ");
            object result = klient1.SaleBeetween2013_2014();
            Console.WriteLine(result);
            Console.Write($"Policz sumę z jednego dnia: ");
            result = klient1.SumSaleInDay(3, 6, 2012);
            Console.WriteLine(result);
            Console.Write($"Policz liczbe sprzedanych produktów dla pracownika o podanych danych : ");
            result = klient1.NumberOfSoldProduct("Shu", "Ito");
            Console.WriteLine(result);
            klient1.Close();

            Console.WriteLine("Klient 2: ");
            Console.WriteLine($"Pobierz informacje o zamówieniach w przedziale 2013 - 2014: ");
            result = klient2.SaleBeetween2013_2014();
            Console.WriteLine(result);
            Console.Write($"Policz sumę z jednego dnia: ");
            result = klient2.SumSaleInDay(3, 6, 2012);
            Console.WriteLine(result);
            Console.Write($"Policz liczbe sprzedanych produktów dla pracownika o podanych danych : ");
            result = klient2.NumberOfSoldProduct("Shu", "Ito");
            Console.WriteLine(result);
            klient2.Close();

            Console.WriteLine("Klient 3: ");
            Console.WriteLine($"Pobierz informacje o zamówieniach w przedziale 2013 - 2014: ");
            result = klient3.SaleBeetween2013_2014();
            Console.WriteLine(result);
            Console.Write($"Policz sumę z jednego dnia: ");
            result = klient3.SumSaleInDay(3, 6, 2020);
            Console.WriteLine(result);
            Console.Write($"Policz liczbe sprzedanych produktów dla pracownika o podanych danych : ");
            klient3.NumberOfSoldProduct("Shu", "Ito");
            Console.WriteLine(result);
            klient3.Close(); 
        }
    }
}
