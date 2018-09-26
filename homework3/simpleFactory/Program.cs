using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleFactory
{
    class program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入你想创建的图形：");
            String shape = Console.ReadLine();
            Figure f1 = Factory.createFigure(shape);
            Console.WriteLine("图形面积为： " + f1.Getarea());

        }
    }

    public abstract class Figure
    {
        public abstract double Getarea();
    }
    //三角形类
    class Triangle : Figure
    {
        double x, y, z;
        double area;
        public Triangle(double x, double y, double z)
        {

            this.x = x;
            this.y = y;
            this.z = z;
            double p = (x + y + z) / 2;
            this.area = Math.Sqrt(p * (p - x) * (p - y) * (p - z));
        }

        public override double Getarea()
        {
            return this.area;
        }

    }
    //圆类
    class Circle : Figure
    {
        double area;
        double radius;
        public Circle(double radius)
        {
            this.radius = radius;
            this.area = 3.14 * radius * radius;
        }

        public override double Getarea()
        {
            return this.area;
        }
    }
    //正方形类
    class Cube : Figure
    {
        double area;
        double x;
        public Cube(double x)
        {
            this.x = x;
            this.area = x * x;
        }

        public override double Getarea()
        {
            return this.area;
        }
    }

    //矩形类
    class Rectangular : Figure
    {

        double width;
        double length;
        double area;
        public Rectangular(double width, double length)
        {
            this.width = width;
            this.length = length;
            this.area = width * length;
        }
        public override double Getarea()
        {
            return this.area;
        }
    }
    class Factory
    {
        public static Figure createFigure(String shape)
        {
            if (shape == "三角形")
            {
                Console.WriteLine("请输入想要创建的三角形的三边长：");
                double x = Convert.ToDouble(Console.ReadLine());
                double y = Convert.ToDouble(Console.ReadLine());
                double z = Convert.ToDouble(Console.ReadLine());
                if (x <= 0 || y <= 0 || z <= 0 || (x + y <= z) || (x - y >= z))
                {
                    Console.WriteLine("数据无效");
                    return null;
                }
                else
                {
                    return new Triangle(x, y, z);
                }

            }
            else if (shape == "正方形")
            {
                Console.WriteLine("请输入想要创建的正方形的边长：");
                double x = Convert.ToDouble(Console.ReadLine());
                if (x <= 0)
                {
                    Console.WriteLine("数据无效");
                    return null;
                }
                else
                {
                    return new Cube(x);
                }
            }
            else if (shape == "圆形")
            {
                Console.WriteLine("请输入想要创建的圆形的半径：");
                double r = Convert.ToDouble(Console.ReadLine());
                if (r <= 0)
                {
                    Console.WriteLine("数据无效");
                    return null;
                }
                else
                {
                    return new Circle(r);
                }
            }
            else if (shape == "矩形" || shape == "长方形")
            {
                Console.WriteLine("请输入想要创建的矩形的长和宽：");
                double length = Convert.ToDouble(Console.ReadLine());
                double width = Convert.ToDouble(Console.ReadLine());
                if (length <= 0 || width <= 0)
                {
                    Console.WriteLine("数据无效");
                    return null;
                }
                else
                {
                    if (length < width)
                    {
                        double a = length;
                        length = width;
                        width = a;
                    }
                    return new Rectangular(width, length);
                }
            }
            else
            {
                Console.WriteLine("数据无效");
                return null;
            }



        }

    }
}
