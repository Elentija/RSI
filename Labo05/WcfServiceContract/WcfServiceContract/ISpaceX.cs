using System.Net.Security;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WcfServiceContract
{
    [ServiceContract(ProtectionLevel = ProtectionLevel.None)]
    public interface ISpaceX
    {
        [OperationContract]
        Task<string> GetCompanyInfo();

        [OperationContract]
        Task<object> GetLaunches();

        [OperationContract]
        double Pomnoz(double n1, double n2);

        [OperationContract]
        double Sumuj(double n1);
    }
}
