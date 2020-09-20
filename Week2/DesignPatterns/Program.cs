using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> types = new List<string> { "Triangle", "Rectangle", "Square" };
            Shape shape = null;
            Random rand = new Random();
            double sum = 0;
            int InValid = 0;//无效形状的个数
            for(int i=1;i<=100;i++)
            {
                shape = Factory.ShapeSelection(types[rand.Next(types.Count)]);
                if (shape.Calculate() == 0) { InValid++; } else sum += shape.Calculate();
            }
            Console.WriteLine($"The area of 100 shapes is {sum}");
            Console.WriteLine($"The number of invalid shape is {InValid}");
        }
    }
}
