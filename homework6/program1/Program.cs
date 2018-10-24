using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace program1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Product p1 = new Product("联想拯救者Y7000", 10030);
            Product p2 = new Product("联想小新潮7000", 11299);
            Product p3 = new Product("华硕灵耀RX310", 8939);
            Product p4 = new Product("华硕飞行堡垒FX63VD", 12000);
            Product p5 = new Product("华硕FX80GM-飞行堡垒星途版", 13000);
            Product.AddProducts(p1);
            Product.AddProducts(p2);
            Product.AddProducts(p3);
            Product.AddProducts(p4);
            Product.AddProducts(p5);
            OrderDetails a1 = new OrderDetails("ljj", "联想拯救者Y7000");
            OrderDetails a2 = new OrderDetails("ly", "联想小新潮7000");
            OrderDetails a3 = new OrderDetails("lr", "华硕灵耀RX310");
            OrderDetails a4 = new OrderDetails("ljy", "华硕飞行堡垒FX63VD");
            OrderDetails a5 = new OrderDetails("lry", "华硕FX80GM-飞行堡垒星途版");
            OrderService.AddOrder(a1);
            OrderService.AddOrder(a2);
            OrderService.AddOrder(a3);
            OrderService.AddOrder(a4);
            OrderService.AddOrder(a5);
            OrderService.SeekByName("ljj");
            OrderService.PrintAll();
            OrderService.SeekAsPrice(10000, 1, 1);
            OrderService.DeleteAsName("lry");
            OrderService.DeleteAsNum(4);
            OrderService.PrintAll();
            OrderService.Export("order.xml",a1);
            OrderService.Inport("order.xml");

        }

    }
}
