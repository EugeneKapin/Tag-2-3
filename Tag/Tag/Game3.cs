using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    class Game3 : Game2
    {
        private List<string> History;
        //private List<int> History1;

        public Game3(params int[] meaning) : base (meaning)
        {

            History = new List<string>();
            //History1 = new List<int>();
    }


        public override void Shift(int value)
        {
            base.Shift(value);
            //History1.Add(value);
            History.Add(string.Format("{0} with coordinate ({1}) replaced to ({2})", 
                        value, dictionary[0], dictionary[value]));
        }

        public string GetStep(int value)
        {
            //this.Shift(value);
            //History.Last();
            return History[value - 1];
        }
    }
}

