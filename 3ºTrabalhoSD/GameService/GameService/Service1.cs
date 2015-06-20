using System;
using System.Collections.Generic;
using System.ServiceModel;
using Service.Game;
using Service.Service;

namespace Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class Service1 : IServiceClient, IServiceManager
    {
        private static readonly String[] Msgs =
        {
            "Already played here!","You WON!!!","You just won a life","You just lost a life",
            "You just DIED!!!!!","Nothing happened","Invalid move"
        };

        private Board _jogo;
        private readonly Dictionary<string, Player> _jogadores = new Dictionary<string, Player>();

        public void RegisterPlayer(string name)
        {
            if (_jogo == null)
                throw new FaultException<RegisterException>(new RegisterException("Game not started"),
                    new FaultReason("Game not started"));
            string sessionId = OperationContext.Current.SessionId;
            var a = OperationContext.Current.GetCallbackChannel<INotification>();
            if (_jogadores.ContainsKey(sessionId))
            {
                _jogadores[sessionId].ClientCallBack.SetNotification("Player already registered");
                return;
            }
            var j = new Player(name, sessionId, OperationContext.Current.GetCallbackChannel<INotification>());
            _jogadores.Add(sessionId, j);
            _jogadores[sessionId].ClientCallBack.SetNotification("Player registered");
        }

        public void RemovePlayer(string playerId)
        {
            _jogadores.Remove(playerId);
        }

        public void Play(int x, int y)
        {
            string sessionId = OperationContext.Current.SessionId;
            int result = _jogo.Play(_jogadores[sessionId], x, y);
            switch (result)
            {
/*                case 0: //return Msgs[0];
                case 1:
                    //TODO notificações de virotia e derrota
                    //return Msgs[1];
                case 2: //return Msgs[2];
                case 3: //return Msgs[3];
                case 4: //return Msgs[4];
                case 5: //return Msgs[5];
                default: //return Msgs[6];*/
            }
        }

        /***************************GESTOR*****************************/
        public void CreateBoard(int size)
        {
            _jogo = new Board(size);
        }
        public void EndGame()
        {
            throw new NotImplementedException();
        }
    }
}
