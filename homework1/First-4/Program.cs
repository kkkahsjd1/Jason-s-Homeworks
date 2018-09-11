using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
           
            Console.Write("Please write the first number: ");
            s = Console.ReadLine();
            double a = Int32.Parse(s);
            Console.Write("Please write the second number: ");
            s = Console.ReadLine();
            double b = Int32.Parse(s);
            double product = a *b;
            Console.Write("The product is: "+product);
        }
    }
}
