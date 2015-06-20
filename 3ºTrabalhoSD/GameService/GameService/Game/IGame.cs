using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Game
{
    public interface IGame
    {
        int Play(Player playerId, int x, int y);
    }
}
