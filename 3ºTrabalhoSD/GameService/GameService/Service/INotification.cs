using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    [ServiceContract]
    public interface INotification
    {
        [OperationContract(IsOneWay = true)]
        void SetPublicity(string p);
        [OperationContract(IsOneWay = true)]
        void SetNotification(string p);
        [OperationContract(IsOneWay = true)]
        void SetPlayerData(string p);
    }
}
