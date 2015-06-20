using System.ServiceModel;

namespace Service.Service
{
    [ServiceContract]
    public interface IServiceManager
    {
        [OperationContract] void CreateBoard(int size);
        [OperationContract] void SendData(string value);
        [OperationContract] void SuspendGame(bool value);
        [OperationContract] void EndGame();
    }
}
