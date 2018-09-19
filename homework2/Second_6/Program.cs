using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Number:");
            int m = int.Parse(Console.ReadLine());
            int i = 2;
            Console.Write("素数因子为：");
            while (i <= m)
            {
                if (m % i == 0)
                {
                    while (m % i == 0)
                    {
                        m = m / i;
                    }
                    Console.Write(i + " ");
                }
                else
                    ++i;
            }
        }
    }
}
