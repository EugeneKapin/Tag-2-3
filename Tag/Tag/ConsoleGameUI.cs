using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    class ConsoleGameUI
    {
        IPlayable objPlayable;

        public ConsoleGameUI(IPlayable game)
        {
            objPlayable = game;
        }

        public void Playingfield()
        {
            Console.WriteLine("Playing field");
            for (int i = 0; i < (objPlayable as Game).side; i++)
            {
                for (int j = 0; j < (objPlayable as Game).side; j++)
                {
                    Console.Write("{0}\t", (objPlayable as Game)[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void StartGame()
        {
            Playingfield();
            while (!objPlayable.IsFinished())
            {
                int value;
                Console.WriteLine("Enter the number you want to move");
                if (Int32.TryParse(Console.ReadLine(), out value))
                {
                    if (value >= 0)
                    {
                        objPlayable.Shift(value);
                        Playingfield();
                    }
                    else
                    {
                        Console.WriteLine("This number is less than zero");
                    }
                }
                else
                {
                    Console.WriteLine("Can not read line, try again");
                }
            }
            Console.WriteLine("Congratulations, the game is over");          
        }
    }
}
