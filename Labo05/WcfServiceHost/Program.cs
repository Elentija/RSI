using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WcfServiceContract;
using static System.Console;


namespace WcfServiceHost
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

            // Krok 1 Utworz URI dla bazowego adresu serwisu.
            Uri baseAddress = new Uri("http://25.44.16.181:11115/mojkalkulator");
            // Krok 2 Utworz instancje serwisu.
            ServiceHost mojHost = new
            ServiceHost(typeof(DbAction), baseAddress);
            // Krok 3 Dodaj endpoint.
            WSHttpBinding mojBanding = new WSHttpBinding();
            mojBanding.Security.Mode = SecurityMode.None;
            mojHost.AddServiceEndpoint(typeof(IDbAction),
            mojBanding, "endpoint1");
            // Krok 4 Ustaw właczenie metadanych.
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            mojHost.Description.Behaviors.Add(smb);
            try
            {
                BasicHttpBinding binding2 = new BasicHttpBinding();
                ServiceEndpoint endpoint2 = mojHost.AddServiceEndpoint(
                 typeof(IDbAction), binding2, "endpoint2");
                ServiceEndpoint endpoint3 = mojHost.Description.Endpoints.Find(new Uri("http://25.44.16.181:11115/mojkalkulator/endpoint3"));

                Console.WriteLine("\n---> Endpointy:");
                Console.WriteLine("\nService endpoint {0}:", endpoint2.Name);
                Console.WriteLine("Binding: {0}", endpoint2.Binding.ToString());
                Console.WriteLine("ListenUri: {0}", endpoint2.ListenUri.ToString());

                Console.WriteLine("\nService endpoint {0}:", endpoint3.Name);
                Console.WriteLine("Binding: {0}", endpoint3.Binding.ToString());
                Console.WriteLine("ListenUri: {0}", endpoint3.ListenUri.ToString());

                // Krok 5 Uruchom serwis.
                mojHost.Open();
                Console.WriteLine("Serwis jest uruchomiony.");
                Console.WriteLine("Nacisnij <ENTER> aby zakonczyc.");
                Console.WriteLine();
                Console.ReadLine(); // aby nie kończyć natychmiast:
                mojHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("Wystapil wyjatek: {0}", ce.Message);
                mojHost.Abort();
            }
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
