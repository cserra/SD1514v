using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Game
{
    public class Board
    {
        private char[] chars = {'M', 'V', 'O'};

        private Cell[,] map;
        private int size;

        public Board(int size)
        {
            map = new Cell[size, size];
            this.size = size;
            FillMatrix();
            PrintMatrix();
        }

        private void PrintMatrix()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(map[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }

        private void FillMatrix()
        {
            Random rnd = new Random();
            int x = rnd.Next(0, size);
            Random rnd2 = new Random();
            int y = rnd2.Next(0, size);
            map[x, y] = new Cell('T');

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == x && j == y) continue;
                    int type = rnd.Next(0, 3);
                    map[i, j] = new Cell(chars[type]);
                }
            }
        }

        public int Play(Player playerId, int x, int y)
        {
            if (x >= size || y >= size)
                return -1;
            return map[x, y].Play(playerId);
        }
    }
}
