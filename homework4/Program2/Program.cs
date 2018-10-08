using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {

            OrderDetails p1 = new OrderDetails("ll", "袜子");
            OrderDetails p2 = new OrderDetails("df", "鞋子");
            OrderDetails p3 = new OrderDetails("dh", "帽子");
            OrderDetails p4 = new OrderDetails("dfs", "手套");
            OrderService.AddOrder(p1);
            OrderService.AddOrder(p2);
            OrderService.AddOrder(p3);
            OrderService.PrintAll();
            OrderService.SeekByName("ll");
            OrderService.SeekByNum(1);
            OrderService.SeekByProduct("鞋子");
            OrderService.DeleteAsName("鞋子");
            OrderService.change(p3, p4);
            OrderService.PrintAll();



        }
    }

    public abstract class Order
    {
        public abstract void TakeOrder();
        
    }

    class OrderDetails : Order
    {
        public override void TakeOrder()
        {
            Console.WriteLine("您的"+product+"下单成功，您的订单号为:" + i);
        }
        static int i = 0;
        public string ClientName;
        public int OrderNum;
        public string product;
        public string rAdress;
        public string nowAdress;
        public OrderDetails(string client, string product)
        {
            this.ClientName = client;
            this.product = product;
            this.OrderNum = i++;
            TakeOrder();
        }

    }

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
                    Console.WriteLine("查找结果："+"客户姓名：" + a.ClientName + "\n" + "客户订单号：" + a.OrderNum + "\n" + "商品：" + a.product);
            }
            return list.Find(c => c.ClientName == name);

        }
        public static OrderDetails SeekByNum(int num)
        {
            foreach(OrderDetails a in list)
            {
                if (a.OrderNum==num)
                    Console.WriteLine("查找结果："+"客户姓名：" + a.ClientName + "\n" + "客户订单号：" + a.OrderNum + "\n" + "商品：" + a.product);
            }
            return list.Find(c => c.OrderNum == num);
        }
        public static OrderDetails SeekByProduct(string product)
        {
            foreach (OrderDetails a in list)
            {
                if (a.product == product)
                    Console.WriteLine("查找结果：" + "客户姓名：" + a.ClientName + "\n" + "客户订单号：" + a.OrderNum + "\n" + "商品：" + a.product);
            }
            return list.Find(c => c.product == product);
        }
        public static void DeleteAsNum(int num)
        {
            try
            {
                int i = 0;
                while (list[i].OrderNum == num)
                {
                    list.Remove(list[i]);
                    ++i;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("订单号错误");
            }
        }
        public static  void DeleteAsName(string name)
        {
            try
            {
                int i = 0;
                while (list[i].ClientName == name)
                {
                    list.Remove(list[i]);
                    ++i;
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
                int i = 0;
                while (list[i].product == product)
                {
                    list.Remove(list[i]);
                    ++i;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("商品不存在");
            }
        }
        public static void change(OrderDetails order1,OrderDetails order2)
        {
            
            OrderDetails c = list.Find(p => p == order1);
            Console.WriteLine("更改前： \n" + "客户姓名：" + c.ClientName + "\n" + "客户订单号：" + c.OrderNum + "\n" + "商品：" + c.product);
            c.OrderNum = order2.OrderNum;
            c.ClientName = order2.ClientName;
            Console.WriteLine("更改后： \n" + "客户姓名：" + c.ClientName + "\n" + "客户订单号：" + c.OrderNum + "\n" + "商品：" + c.product);

        }
        public static void PrintAll()
        {
            int i = 1;
            foreach (OrderDetails a in list)
            {
                Console.WriteLine(i+".客户姓名：" + a.ClientName + "\n" + "客户订单号：" + a.OrderNum + "\n" + "商品：" + a.product);
                i++;
            }


        }
    }
}
