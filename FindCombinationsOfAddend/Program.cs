using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            for (int i = 0; i < 1000; i++)
            {
                list.Add(i+1);
            }
            var res = CombinationsFinder.FindCombinationsOfAddend(list, 537);
        }
    }
}
