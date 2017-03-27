using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    class Game2 : Game, IPlayable
    {
        public Game2(params int[] meaning) : base (meaning)
        {
        }

        public virtual void Randomize(int[] values)
        {
            int count = 0;
            Random mass = new Random();
            while (count != values.Length)
            {
                int a = mass.Next(0, values.Length);
                ShiftForRandomize(a);
                count++;
            }
        }

        private void ShiftForRandomize(int value)
        {

            var Numberone = this.GetLocation(value).Item1;
            var Numbertwo = this.GetLocation(value).Item2;
            var Voidx = this.GetLocation(0).Item1;
            var Voidy = this.GetLocation(0).Item2;
            var cellValue = this.Numbers[Voidx, Voidy];
            this.Numbers[Voidx, Voidy] = this.Numbers[Numberone, Numbertwo];
            Voidx = Numberone;
            Voidy = Numbertwo;
            this.Numbers[Voidx, Voidy] = cellValue;
        }

        public bool IsFinished()
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

        public override void Shift(int value)
        {
            base.Shift(value);
        }
    }
}