using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EhrlichSieve_Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            // 用“埃氏筛法”求2~ 100以内的素数(1:合数，0：素数）
            int[] a = new int[101];
            for (int i = 2; i * i <= a.Length; i++)
                if (a[i] == 0)
                    for (int j = i * i; j <= a.Length; j += i)
                        a[j] = 1;
            // 输出最后的结果
            for (int i = 2; i < a.Length; i++)
                if (a[i] == 0)
                    Console.Write(i + " ");
        }
    }
}
