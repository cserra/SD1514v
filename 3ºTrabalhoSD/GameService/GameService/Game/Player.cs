using Service.Service;

namespace Service.Game
{
    public class Player
    {
        public int Lives { get; set; }
        public string Name { get; private set; }
        public string SessionId { get; private set; }
        public string Language { get; set; }
        public INotification ClientCallBack { get; private set; }

        public Player(string s, string sessionId, string lang, INotification clientCallBack)
        {
            Lives = 1;
            Name = s;
            SessionId = sessionId;
            Language = lang;
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

        public override string ToString()
        {
            return Name + "\r\n" + "Vidas: " + Lives + "\n";
        }
    }
}
