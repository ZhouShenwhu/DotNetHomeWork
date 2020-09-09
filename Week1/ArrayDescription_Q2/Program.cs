using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayDescription_Q2
{
    class Program
    {
        static void Main(string[] args)
        {
            double max, min, sum, average;
            double[] a = { 1.2, 2.5, 15.6, 13.4, 15.6 };
            ArrayProcess(a, out max, out min, out sum, out average);
            Console.WriteLine($"max:{max},min:{min},sum:{sum},average:{average}");
        }
        private static void ArrayProcess(double[] a, out double max, out double min, out double sum, out double average)
        {
            min = a[0];
            max = a[0];
            sum = .0;
            foreach (double element in a)
            {
                if (element > max) max = element;
                if (element < min) min = element;
                sum += element;
            }
            average = sum / a.Length;
        }
    }
}
