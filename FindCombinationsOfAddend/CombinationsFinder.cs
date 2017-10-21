using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{
    public class CombinationsFinder
    {
        public static List<Tuple<int, int>> FindCombinationsOfAddend(List<int> addends, int sum)
        {
            var res = new List<Tuple<int, int>>();
            addends = addends.Distinct().ToList();

            for (int i = 0; i < addends.Count; i++)
            {
                for (int j = 0; j < addends.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if ((addends[i] + addends[j]) == sum)
                    {
                        res.Add(new Tuple<int, int>(addends[i], addends[j]));
                        addends.Remove(addends[i]);
                        addends.Remove(addends[j]);
                        --i;
                        break;
                    }
                }
            }

            return res;
        }
    }
}
