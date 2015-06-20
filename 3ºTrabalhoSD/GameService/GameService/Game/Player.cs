﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security.Tokens;
using System.Text;
using System.Threading.Tasks;
using Service.Service;

namespace Service.Game
{
    public class Player
    {
        public int Lives { get; set; }
        public string Name { get; private set; }
        public string SessionId { get; private set; }
        public INotification ClientCallBack { get; private set; }

        public Player(string s, string sessionId, INotification clientCallBack)
        {
            Lives = 1;
            Name = s;
            SessionId = sessionId;
            ClientCallBack = clientCallBack;
        }

        public void AddLife()
        {
            Lives++;
        }

        public bool TakeLife()
        {
            Lives--;
            return Lives == 0;
        }
    }
}
