using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    class Game2 : Game
    {
        public Game2(params int[] meaning) : base (meaning)
        {
        }

        public static Game2 StartRandomize(Game margin)
        {
            int[] meaning = new int[margin.side * margin.side];
            int count = 0;
            for (int i = 0; i < meaning.Length; i++)
            {
                meaning[i] = -1;
            }
            var rand = new Random();
            while (count != meaning.Length)
            {
                int x = rand.Next(0, meaning.Length);
                if (!meaning.Contains(x))
                {
                    meaning[count] = x;
                    count++;
                }
            }
            return new Game2(meaning);
        }

        public bool Win
        {
            get
            {
                for (int i = 0; i < side; i++)
                {
                    for (int j = 0; j < side; j++)
                    {
                        if (i == side - 1 && j == side - 1 && this[i, j] == 0)
                            continue;
                        else if (this[i, j] == i * side + j + 1 && (i != side - 1 || j != side - 1))
                            continue;
                        else return false;
                    }
                }
                return true;
            }
        }
    }
}