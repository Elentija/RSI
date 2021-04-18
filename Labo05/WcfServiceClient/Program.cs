using System;
using System.Net;
using WcfServiceClient.ServiceReference1;
using static System.Console;

namespace WcfServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine(".Net 5.0");
            WriteLine("Daria Hornik, 246700");
            WriteLine("Kamil Graczyk, 246994");
            WriteLine(Environment.MachineName);
            WriteLine(Environment.UserName);
            DateTime thisDay = DateTime.Now;
            WriteLine(thisDay.ToString());
            GetLocalIPAddress();

            //Krok 1: Utworzenie instancji WCF proxy.

            DbActionClient klient1 = new DbActionClient("WSHttpBinding_IDbAction");
            DbActionClient klient2 = new DbActionClient("BasicHttpBinding_IDbAction");

            // Krok 2: Wywolanie operacji uslugi.
            Console.WriteLine("Klient 1: ");
            Console.WriteLine($"Pobierz informacje o zamówieniach w przedziale 2013 - 2014: ");
            object result = klient1.SaleBeetween2013_2014();
            Console.WriteLine(result);
            Console.WriteLine($"Policz sumę z jednego dnia: ");
            result = klient1.SumSaleInDay(3, 6, 2012);
            Console.WriteLine(result);
            Console.WriteLine($"Policz liczbe sprzedanych produktów dla pracownika o podanych danych : ");
            result = klient1.NumberOfSoldProduct("Shu", "Ito");
            Console.WriteLine(result);
            klient1.Close();

            Console.WriteLine("Klient 2: ");
            Console.WriteLine($"Pobierz informacje o zamówieniach w przedziale 2013 - 2014: ");
            result = klient2.SaleBeetween2013_2014();
            Console.WriteLine(result);
            Console.WriteLine($"Policz sumę z jednego dnia: ");
            result = klient2.SumSaleInDay(3, 6, 2012);
            Console.WriteLine(result);
            Console.WriteLine($"Policz liczbe sprzedanych produktów dla pracownika o podanych danych : ");
            result = klient2.NumberOfSoldProduct("Shu", "Ito");
            Console.WriteLine(result);
            klient2.Close();
        }
        public static void GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                WriteLine(ip);
            }
        }
    }
}
