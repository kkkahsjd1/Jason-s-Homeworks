using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_9
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeFind1();
            Console.Write("\n");
            PrimeFind2();
        }
        static void PrimeFind1()
        {
            Console.Write("2到100的素数有：");
            int i = 2;
            bool s;
            for (; i < 100; i++)
            {
                s = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                        s = false;
                }
                if (s)
                    Console.Write(i+" ");
            }
        }
        static void PrimeFind2()
        {
            Console.Write("2到100的素数有：");
            for (int i = 2; i < 101; i++)
            {
                if ((i % 2 == 0 || i % 3 == 0 || i % 5 == 0 || i % 7 == 0) && i != 2 && i != 3 && i != 5 && i != 7)
                    continue;
                else
                    Console.Write(i + " ");
            }
        }//埃氏筛法
    }
}
