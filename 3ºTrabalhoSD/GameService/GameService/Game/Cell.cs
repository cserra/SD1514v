using System;

namespace Service.Game
{
    public class Cell
    {
        private char _itemType;

        public Cell(char itemType)
        {
            _itemType = itemType;
        }
        
        public override String ToString()
        {
            return _itemType + "";
        }

        public int Play(Player p)
        {
            char type = _itemType;
            _itemType = 'O';
            switch (type)
            {
                case 'T':
                    return 1;
                case 'V':
                    p.AddLife();
                    return 2;
                case 'M':
                    if (!p.TakeLife())
                    {
                        return 3;
                    }
                    else
                    {
                        return 4;
                    }
                default:
                    return 5;
            }
        }
    }
}
