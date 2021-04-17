using System;
using System.ServiceModel;

namespace WcfServiceContract
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MojKalkulator : IKalkulator
    {
        double suma = 0;

        public double Dodaj(double n1, double n2)
        {
            var result = n1 + n2;
            Console.WriteLine($"Wywołano metode dodawania dwóch liczb: {n1} + {n2} = {result}");
            return result;
        }
        public double Odejmij(double n1, double n2)
        {
            var result = n1 - n2;
            Console.WriteLine($"Wywołano metode odejmowania dwóch liczb: {n1} - {n2} = {result}");
            return result;
        }
        public double Pomnoz(double n1, double n2)
        {
            var result = n1 * n2;
            Console.WriteLine($"Wywołano metode mnożenia dwóch liczb: {n1} * {n2} = {result}");
            return result;
        }

        public double Sumuj(double n1)
        {
            Console.WriteLine($"Wywołano metode sumowania globalnego: {suma} + {n1} = {suma += n1}");
            return suma;
        }
    }
}
