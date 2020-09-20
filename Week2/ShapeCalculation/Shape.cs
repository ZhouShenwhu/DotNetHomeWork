using System;
using System.Threading;
using static System.Math;
namespace ShapeCalculation
{
    abstract class Shape
    {
        public abstract bool Check();
        public abstract double Calculate();
    }

    class Triangle:Shape
    {
        double a { get; set; }
        double b { get; set; }
        double c { get; set; }

        public Triangle(double a,double b,double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public override bool Check()
        {
            if (a <= 0 || b <= 0 || c < 0) return false;
            if (Max(a, b) <= c && a + b > c) return true;
            if (Max(a, b) <= c && a + b <= c) return false;
            if (Min(a, b) + c > Max(a, b)) return true;   
            return false;
        }
        public override double Calculate()
        {
            if (Check() == true)
            {
                double p = 0.5 * (a + b + c);
                double S = Sqrt(p * (p - a) * (p - b) * (p - c));
                return S;
            }
            else
            {
                Console.WriteLine("输入不合法");
                return 0;
            }
        }
    }

    class Rectangle : Shape
    {
        public double a { get; set; }
        public double b { get; set; }
        public Rectangle(double a,double b)
        {
            this.a = a;
            this.b = b;
        }
        public override bool Check()
        {
            if (a > 0 && b > 0) return true;else return false;
        }
        public override double Calculate()
        {
            if (Check() == true)
            {
                return a * b;
            }
            else
            {
                Console.WriteLine("输入不合法");
                return 0;
            }
        }
    }

    class Square:Rectangle
    {
        public Square(double side) : base(side, side) { }
    }
}
