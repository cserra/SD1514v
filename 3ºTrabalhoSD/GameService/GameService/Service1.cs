using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Service.Game;
using Service.Service;

namespace Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class Service1 : IServiceClient, IServiceManager
    {
        private bool _hasBoard = false;
        private bool _isSuspended = false;
        private static readonly String[] Msgs =
        {
            "Already played here!","You WON!!!","You just won a life","You just lost a life",
            "You just DIED!!!!!","Nothing happened","Invalid move"
        };

        private Board _jogo;
        private readonly Dictionary<string, Player> _players = new Dictionary<string, Player>();

        public void RegisterPlayer(string name, string lang)
        {
            string sessionId = OperationContext.Current.SessionId;
            var callback = OperationContext.Current.GetCallbackChannel<INotification>();
            if (_jogo == null)
                throw new FaultException<RegisterException>(new RegisterException("Game not started"),
                    new FaultReason("Game not started"));
            if (_players.Any(kvp => kvp.Key.Contains(sessionId)))
            {
                NotifyPlayer(_players[sessionId], "Player already registered");
                return;
            }
            var j = new Player(name, sessionId, lang, callback);
            _players.Add(sessionId, j);
            NotifyPlayer(j, j.ToString());
            NotifyAll("New player " + name);
        }

        public void RemovePlayer()
        {
            string sessionId = OperationContext.Current.SessionId;
            _players.Remove(sessionId);
            NotifyAll("Player " + sessionId + " removed");
        }

        public void Play(int x, int y)
        {
            string sessionId = OperationContext.Current.SessionId;
            Player p = _players[sessionId];
            if (!_hasBoard)
            {
                NotifyPlayer(p, "The Game has finished!!!");
                return;
            }
            if (_isSuspended)
            {
                NotifyPlayer(p, "The game is suspended!!");
                return;
            }
            int result = _jogo.Play(p, x, y);
            switch (result)
            {
                case 0:
                    NotifyPlayer(p, Msgs[0]);
                    break;
                case 1:
                    _hasBoard = false;
                    NotifyAll("Player " + p.Name + " won the game");
                    NotifyPlayer(p, Msgs[1]);
                    break;
                case 2:
                    NotifyPlayer(p, Msgs[2]);
                    break;
                case 3:
                    NotifyPlayer(p, Msgs[3]);
                    break;
                case 4:
                    NotifyAll("Player " + p.Name + " just died");
                    NotifyPlayer(p, Msgs[4]);
                    break;
                case 5:
                    NotifyPlayer(p, Msgs[5]);
                    break;
                default:
                    NotifyPlayer(p, Msgs[6]);
                    break;
            }
        }

        /***************************COMUNICATION*****************************/
        private void NotifyAll(string msg)
        {
            foreach (var item in _players)
            {
                item.Value.ClientCallBack.SetNotification(msg);
            }
        }
        private void NotifyAllPublic(string value)
        {
            foreach (var item in _players)
            {
                item.Value.ClientCallBack.SetPublicity(value);
            }
        }
        private void NotifyPlayer(Player p, string msg)
        {
            p.ClientCallBack.SetNotification(msg);
            p.ClientCallBack.SetPlayerData(p.ToString());
        }
        /***************************GESTOR*****************************/
        public void CreateBoard(int size)
        {
            if (_hasBoard)
                NotifyAll("Game restarted");
            _jogo = new Board(size);
            _hasBoard = true;
        }

        public void SendData(string value)
        {
            NotifyAllPublic(value);
        }

        public void SuspendGame(bool value)
        {
            _isSuspended = value;
            if(_isSuspended) NotifyAll("Game suspended");
            else NotifyAll("Game resumed");
        }

        public void EndGame()
        {
            _jogo = null;
            _hasBoard = false;
            _isSuspended = false;
            NotifyAll("Game has been closed by manager");
        }
    }
}
