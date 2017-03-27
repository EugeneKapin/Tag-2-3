using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    public interface IPlayable
    {
        void Randomize(int[] values);
        bool IsFinished();
        void Shift(int value);
    }
}
