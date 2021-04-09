using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            WriteLine("Daria Hornik, 246700");
            WriteLine("Kamil Graczyk, 246994");
            DateTime localDate = DateTime.Now;
            WriteLine(localDate);
            WriteLine(Environment.MachineName);
            WriteLine(Environment.UserName);

            using var channel = GrpcChannel.ForAddress("http://25.43.211.64:5001");
            var client = new Greeter.GreeterClient(channel);

            List<double> myParams = ReadParams();

            var reply = await client.CheckPointsAsync(
                              new CheckPointsRequest { 
                                  A = myParams[0],
                                  B = myParams[1],
                                  C = myParams[2],
                                  X = myParams[3],
                                  Y = myParams[4]
                              });
            String result;
            if (reply.BelongsTo)
            {
                result = "leży na prostej";
            } else
            {
                result = "nie leży na prostej";
            }
            WriteLine($"Na prostej {reply.A}x^2 + {reply.B}x + {reply.C} = 0 punkt x:{reply.X} y:{reply.Y} {result}");
            WriteLine("Press any key to exit...");
            ReadKey();


        }

        private static List<double> ReadParams()
        {
            WriteLine("Wprowadź współczynniki:");
            string[] parms = { "A", "B", "C", "X", "Y" };
            List<double> numbers = new List<double>();
            foreach (var param in parms)
            {
                bool success;
                double paramD;
                do
                {
                    Write($"{param} = ");
                    string numberStr = ReadLine();
                    success = double.TryParse(numberStr, out paramD);
                } while (!success);
                numbers.Add(paramD);
            }

            return numbers;
        }
    }
}
