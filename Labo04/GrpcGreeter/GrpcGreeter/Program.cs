using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace GrpcGreeter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WriteLine("Daria Hornik, 246700");
            WriteLine("Kamil Graczyk, 246994");
            WriteLine(Environment.MachineName);
            WriteLine(Environment.UserName);
            DateTime thisDay = DateTime.Now;
            WriteLine(thisDay.ToString());

            CreateHostBuilder(args).Build().Run();
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
