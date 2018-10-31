using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace WindowsForms
{
    public class OrderService
    {
        List<Product> products;
        private static List<OrderDetails> list = new List<OrderDetails>();
        //add order into list
        public static List<OrderDetails> GetList()
        {
            return list;
        }
        public static void AddOrder(OrderDetails order)
        {
            if ((Product.products.Find(a => a.Goods == order.Product)) != null)
            {
                foreach (Product a in Product.products)
                {
                    if (a.Goods == order.Product)
                    {
                        order.Price = a.Price;
                        list.Add(order);                        
                    }
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("product doesn't exist");
            } 
        }
        //seek order by name
        public static OrderDetails SeekByName(string name)
        {
            var m = from n in list
                    where n.Client == name
                    select n;
            foreach (OrderDetails a in m)
            {
                Console.WriteLine("您要查找的订单：");
                Console.WriteLine(a);
            }
            return list.Find(c => c.Client == name);
        }
        //seek order by num
        public static OrderDetails SeekByNum(int num)
        {

            var m = from n in list
                    where n.Num == num
                    select n;
            foreach (OrderDetails a in m)
            {
                Console.WriteLine("您要查找的订单：");
                Console.WriteLine(a);
            }
            return list.Find(c => c.Num == num);
        }
        //seek order by Product's name
        public static OrderDetails SeekByProduct(string Product)
        {
            var m = from n in list
                    where n.Product == Product
                    select n;
            foreach (OrderDetails a in m)
            {
                Console.WriteLine("您要查找的订单：");
                Console.WriteLine(a);
            }
            return list.Find(c => c.Product == Product);
        }
        //delete order by num
        public static void DeleteAsNum(int num)
        {
            try
            {
                for (int i =0;list[i] !=null;i++)
                {
                    if (list[i].Num == num)
                    {
                        list.Remove(list[i]);
                        Console.WriteLine($"订单号为：{num}的订单删除成功");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("订单号错误");
            }
        }
        //1 for descending, 0 for ascending
        //1 for morethan and equals, 0 for lessthan and equals
        public static void SeekAsPrice(int price, int order, int index)
        {
            if (order == 1)
            {
                if (index == 1)
                {
                    var m = from n in list
                            where n.Price >= price
                            orderby n.Price descending
                            select n;
                    foreach (OrderDetails a in m)
                    {
                        Console.WriteLine("您要查找的订单：");
                        Console.WriteLine(a);
                    }
                }

                else if (order == 0)
                {

                    var m = from n in list
                            where n.Price <= price
                            orderby n.Price descending
                            select n;
                    foreach (OrderDetails a in m)
                    {
                        Console.WriteLine("您要查找的订单：");
                        Console.WriteLine(a);
                    }
                }

            }
            else if (order == 0)
            {
                if (index == 1)
                {
                    var m = from n in list
                            where n.Price >= price
                            orderby n.Price ascending
                            select n;
                    foreach (OrderDetails a in m)
                    {
                        Console.WriteLine("您要查找的订单：");
                        Console.WriteLine(a);
                    }
                }

                else if (order == 0)
                {

                    var m = from n in list
                            where n.Price <= price
                            orderby n.Price ascending
                            select n;
                    foreach (OrderDetails a in m)
                    {
                        Console.WriteLine("您要查找的订单：");
                        Console.WriteLine(a);
                    }
                }
            }

        }


        //delete order by name
        public static void DeleteAsName(string name)
        {
            try
            {
                for (int i = 0; list[i] != null; i++)
                {
                    if (list[i].Client == name)
                    {
                        list.Remove(list[i]);
                        Console.WriteLine($"用户名为：{name}的订单删除成功");
                    }
                }
            }
            catch
            {
                Console.WriteLine("用户姓名错误");
            }
        }
        //delete order by Product's name
        public static void DeleteAsPro(string Product)
        {
            try
            {
                for (int i = 0; list[i] != null; i++)
                {
                    if (list[i].Product == Product)
                    {
                        list.Remove(list[i]);
                        Console.WriteLine($"商品为：{Product}的订单删除成功");
                    }
                }
            }
            catch
            {
                Console.WriteLine("商品不存在");
            }
        }
        //change order
        public static void Change(OrderDetails order1, OrderDetails order2)
        {

            OrderDetails c = list.Find(p => p == order1);
            Console.WriteLine("更改前： ");
            Console.WriteLine(c);
            c.Num = order2.Num;
            c.Client = order2.Client;
            c.Product = order2.Product;
            c.Price = order2.Price;
            Console.WriteLine("更改后： ");
            Console.WriteLine(c);

        }
        //print all orders
        public static void PrintAll()
        {
            int i = 1;
            foreach (OrderDetails a in list)
            {
                Console.WriteLine("=========================================================");
                Console.WriteLine(i + "\t" + a);
                i++;
            }
        }
        //对象xml序列化
        public static void Export(string FileName, OrderDetails obj)
        {
            try
            {
                XmlSerializer xmlser = new XmlSerializer(typeof(OrderDetails));
                FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.ReadWrite);                
                xmlser.Serialize(fs, obj);
                fs.Close();
                string xml = File.ReadAllText(FileName);
                Console.WriteLine(xml);

            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception:{e.ToString()}");
            }
        }
    //整个集合xml序列化
    public static void Export(string FileName)
    {
        try
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(OrderDetails));
            FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.ReadWrite);
            foreach (OrderDetails obj in list)
            {
                xmlser.Serialize(fs, obj);
            }
            fs.Close();
            string xml = File.ReadAllText(FileName);
            Console.WriteLine(xml);

        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception:{e.ToString()}");
        }
    }
    //反序列化
    public static void Inport(String XmlFlie)
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(OrderDetails));
                FileStream sr = new FileStream(XmlFlie, FileMode.Open);
                Object ord = formatter.Deserialize(sr);
                sr.Close();
                Console.WriteLine(ord);
               

            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception:{e.ToString()}");
            }

        }



    }
}
