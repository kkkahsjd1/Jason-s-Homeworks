using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class OrderService
    {
        private static List<OrderDetails> list = new List<OrderDetails>();

        public static void AddOrder(OrderDetails order)
        {
            list.Add(order);
        }
        public static OrderDetails SeekByName(string name)
        {
            foreach (OrderDetails a in list)
            {
                if (a.ClientName == name)
                    Console.WriteLine("======================================================");
                    Console.WriteLine("查找结果： \t" + "客户姓名：" + a.ClientName + " \t" + "客户订单号：" + a.OrderNum + " \t" + "商品：" + a.product);
            }
            return list.Find(c => c.ClientName == name);

        }
        public static OrderDetails SeekByNum(int num)
        {
            foreach (OrderDetails a in list)
            {
                if (a.OrderNum == num)
                    Console.WriteLine("===============================================");
                    Console.WriteLine("查找结果： \t" + "客户姓名：" + a.ClientName + " \t" + "客户订单号：" + a.OrderNum + " \t" + "商品：" + a.product);
            }
            return list.Find(c => c.OrderNum == num);
        }
        public static OrderDetails SeekByProduct(string product)
        {
            foreach (OrderDetails a in list)
            {
                if (a.product == product)
                    Console.WriteLine("================================================");
                    Console.WriteLine("查找结果： \t" + "客户姓名：" + a.ClientName + " \t" + "客户订单号：" + a.OrderNum + " \t" + "商品：" + a.product);
            }
            return list.Find(c => c.product == product);
        }
        public static void DeleteAsNum(int num)
        {
            try
            {
                foreach(OrderDetails a in list)
                {
                    if (a.OrderNum == num)
                    {
                        list.Remove(a);
                        Console.WriteLine($"订单号为：{num}的订单删除成功");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("订单号错误");
            }
        }
        public static void DeleteAsName(string name)
        {
            try
            {
                foreach (OrderDetails a in list)
                {
                    if (a.ClientName== name)
                    { 
                        list.Remove(a);
                        Console.WriteLine($"用户名为：{name}的订单删除成功");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("用户姓名错误");
            }
        }
        public static void DeleteAsPro(string product)
        {
            try
            {
                foreach (OrderDetails a in list)
                {
                    if (a.product == product)
                    {
                        list.Remove(a);
                        Console.WriteLine($"商品为：{product}的订单删除成功");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("商品不存在");
            }
        }
        public static void change(OrderDetails order1, OrderDetails order2)
        {

            OrderDetails c = list.Find(p => p == order1);
            Console.WriteLine("更改前： \t" + "客户姓名：" + c.ClientName + "\t" + "客户订单号：" + c.OrderNum + "\t" + "商品：" + c.product);
            c.OrderNum = order2.OrderNum;
            c.ClientName = order2.ClientName;
            c.product = order2.product;
            Console.WriteLine("更改后： \t" + "客户姓名：" + c.ClientName + "\t" + "客户订单号：" + c.OrderNum + "\t" + "商品：" + c.product);

        }

        public static void PrintAll()
        {
            int i = 1;
            foreach (OrderDetails a in list)
            {
                Console.WriteLine("================================================");
                Console.WriteLine(i + ".客户姓名：" + a.ClientName + "\t" + "客户订单号：" + a.OrderNum + "\t" + "商品：" + a.product);
                i++;
            }


        }
    }
}
