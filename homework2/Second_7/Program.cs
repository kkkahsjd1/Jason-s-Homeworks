using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = new int[10] { 100, 203, 32, 34, 55, 2, 13, 4, 2, 23 };
            double average = Convert.ToDouble(SumOfArr(ints)) / ints.Length;
            Console.WriteLine("数组之和为：" + SumOfArr(ints));
            Console.WriteLine("数组最大值为：" + MaxInArr(ints));
            Console.WriteLine("数组最小值为：" + MinInArr(ints));
            Console.WriteLine("数组平均值为：" + average);
        }
        static int MaxInArr(int[] ints)
        {
            int max = ints[0];
            for (int i = 0; i < ints.Length; i++)
            {
                if (ints[i] > max)
                {
                    max = ints[i];
                }
            }
            return max;
        }
        static int MinInArr(int[] ints)
        {
            int min = ints[0];
            for (int i = 0; i < ints.Length; i++)
            {
                if (ints[i] < min)
                {
                    min = ints[i];
                }
            }
            return min;
        }
        static int SumOfArr(int[] ints)
        {
            int sum = 0;
            for (int i = 0; i < ints.Length; i++)
            {
                sum += ints[i]; 
            }
            return sum;
        }
    }
}
