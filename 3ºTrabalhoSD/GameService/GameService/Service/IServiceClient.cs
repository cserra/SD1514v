using System.ServiceModel;

namespace Service.Service
{
    [ServiceContract(Namespace = "Silverlight", CallbackContract = typeof(INotification))]
    public interface IServiceClient
    {
        [FaultContract(typeof(RegisterException))]
        [OperationContract] void RegisterPlayer(string name); //returns new player ID
        [OperationContract] void RemovePlayer(string playerId);
        [OperationContract] void Play(int x, int y);
    }
}
