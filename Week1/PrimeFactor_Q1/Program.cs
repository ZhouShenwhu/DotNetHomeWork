using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactor_Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*编写程序输出用户指定数据的所有素数因子。*/
            Console.Write("Please input a integer:");
            if (!(int.TryParse(Console.ReadLine(), out int num)))
                Console.WriteLine("Decode Error!");

            List<int> Prime = new List<int>();
            Prime.Add(2);
            for (int i = 3; i <= num; i++)
                if (isPrime(i))
                    Prime.Add(i);

            foreach (int i in Prime)
                Console.Write(i + " ");
        }
        static bool isPrime(int a)
        {
            for (int i = 2; i * i <= a; i++)
                if (a % i == 0)
                    return false;
            return true;
        }
    }
}
