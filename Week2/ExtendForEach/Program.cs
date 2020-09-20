using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExtendForEach
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> mylist = new GenericList<int>();
            List<int> elements = new List<int>{ 5, 6, 8, 32, 4, 3, 8, 5, 84, 5 };
            foreach(int e in elements) { mylist.Add(e); }
            int max = 0, min = 0, sum = 0;
            mylist.ForEach(x => max = Math.Max(x, max));
            mylist.ForEach(x => min = Math.Min(x, min));
            mylist.ForEach(x => sum += x);
            Console.WriteLine($"max:{max},min:{min},sum:{sum}");
        }
    }
}
