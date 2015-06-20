using System.ServiceModel;

namespace Service.Service
{
    [ServiceContract]
    public interface IServiceManager
    {
        [OperationContract] void CreateBoard(int size);
    }
}
