using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeCalculation;

namespace ShapeCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle myTriangle = new Triangle(3, 4, 5);
            Console.WriteLine($"三角形的面积为{myTriangle.Calculate()}");
            Rectangle myRectangle = new Rectangle(5, 6);
            Console.WriteLine($"长方形的面积为{myRectangle.Calculate()}");
            Square mySquare = new Square(5);
            Console.WriteLine($"正方形的面积为{mySquare.Calculate()}");
        }
    }
}
