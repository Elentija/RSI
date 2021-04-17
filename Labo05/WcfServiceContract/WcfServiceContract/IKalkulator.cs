using System.Net.Security;
using System.ServiceModel;

namespace WcfServiceContract
{
    [ServiceContract(ProtectionLevel = ProtectionLevel.None)]
    public interface IKalkulator
    {
        [OperationContract]
        double Dodaj(double n1, double n2);
        [OperationContract]
        double Odejmij(double n1, double n2);
        [OperationContract]
        double Pomnoz(double n1, double n2);

        [OperationContract]
        double Sumuj(double n1);
    }
}
