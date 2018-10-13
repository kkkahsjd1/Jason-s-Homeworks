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
            OrderService.DeleteAsPro("鞋子");
            OrderService.change(p3, p4);
            OrderService.PrintAll();



        }
    }


}
