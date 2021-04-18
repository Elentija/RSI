using System.Net.Security;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WcfServiceContract
{
    [ServiceContract(ProtectionLevel = ProtectionLevel.None)]
    public interface IDbAction
    {
        [OperationContract]
        Task<object> SaleBeetween2013_2014();

        [OperationContract]
        Task<object> SumSaleInDay(int d, int m, int y);

        [OperationContract]
        Task<object> NumberOfSoldProduct(string name, string lastname);
    }
}
