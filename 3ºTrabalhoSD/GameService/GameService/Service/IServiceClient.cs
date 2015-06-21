using System.ServiceModel;

namespace Service.Service
{
    [ServiceContract(Namespace = "Silverlight", CallbackContract = typeof(INotification))]
    public interface IServiceClient
    {
        [FaultContract(typeof(RegisterException))]
        [OperationContract] void RegisterPlayer(string name, string lang); //returns new player ID
        [OperationContract] void RemovePlayer();
        [OperationContract] void Play(int x, int y);
    }
}
