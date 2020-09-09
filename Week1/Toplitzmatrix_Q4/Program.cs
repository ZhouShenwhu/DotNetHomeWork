using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toplitzmatrix_Q4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = { { 1, 2, 3, 4 }, { 5, 1, 2, 3 }, { 9, 5, 1, 2 } };
            Console.WriteLine(isToeplitzMatrix(matrix));
        }

        static bool isToeplitzMatrix(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0) - 1; i++)
                for (int j = 0; j < a.GetLength(1) - 1; j++)
                    if (a[i, j] != a[i + 1, j + 1])
                        return false;
            return true;
        }
    }
}
