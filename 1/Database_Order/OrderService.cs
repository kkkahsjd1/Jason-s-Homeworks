using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace Database_Order
{
    public class OrderService
    {
        private static List<OrderDetails> list = new List<OrderDetails>() ;
        
        //add order into list
        public static List<OrderDetails> GetList()
        {
            return list;
        }
        //判断是否有重复订单号
        public static bool NoInnerTest(List<OrderDetails> list, OrderDetails order)
        {
            if (list.Find(a => a.No==order.No) != null)
            { return false; }
            else
                return true;
        }
        
        public static string Setnum()
        {
            string p1 = DateTime.Now.ToString("yyyyMMdd") + "000";
            if (list.Count == 0)
            {
                return DateTime.Now.ToString("yyyyMMdd") + "001";
            }
            else if (Int64.Parse(list[list.Count - 1].No) < Int64.Parse(p1))
            {
                return DateTime.Now.ToString("yyyyMMdd") + "001";
            }
            else
            {
                return (Int64.Parse(list[list.Count - 1].No) + 1).ToString();
            }
        }
        public static void AddOrder(Customer cus, OrderDetails order)
        {

            if (((Product.products.Find(a => a.Goods == order.Goods)) != null) && (cus != null))
            {
                foreach (Product a in Product.products)
                {
                    if (a.Goods == order.Goods)
                    {
                        order.PhoneNum = cus.PhoneNum;
                        order.Client = cus.Name;
                        order.Price = a.Price;
                        list.Add(order);
                    }
                }
            }
            else if (Product.products.Find(a => a.Goods == order.Goods) == null)
            {
                throw new Exception("不存在该商品");
            }
            else
            {
                throw new Exception("Mission Failed!");
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
                    where n.Goods == Product
                    select n;
            foreach (OrderDetails a in m)
            {
                Console.WriteLine("您要查找的订单：");
                Console.WriteLine(a);
            }
            return list.Find(c=>c.Goods == Product);
        }
        //delete order by num
        public static void DeleteAsNum(int num)
        {
            try
            {
                list.Remove(list.Find(c => c.Num == num));
                Console.WriteLine($"序列号为：{num}的订单删除成功");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: ", e);
            }
        }
        public static void DeleteAsNo(string no)
        {
            try
            {
                list.Remove(list.Find(c => c.No == no));
                Console.WriteLine($"订单号为：{no}的订单删除成功");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: ", e);
            }
        }
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
                list.Remove(list.Find(c => c.Client == name));
                Console.WriteLine($"用户名为：{name}的订单删除成功");
                
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
                list.Remove(list.Find(c => c.Goods == Product));
                Console.WriteLine($"商品为：{Product}的订单删除成功");

            }
            catch
            {
                Console.WriteLine("商品不存在");
            }
        }
        //change order
        public static void Change(OrderDetails order1, OrderDetails order2)
        {
            if (NoInnerTest(list, order2) || order2.No == order1.No)
            {
                OrderDetails c = list.Find(p => p == order1);
                Console.WriteLine("更改前： ");
                Console.WriteLine(c);
                c.Num = order2.Num;
                c.Client = order2.Client;
                c.Goods = order2.Goods;
                c.Price = order2.Price;
                Console.WriteLine("更改后： ");
                Console.WriteLine(c);
            }
            else
                Console.WriteLine("mission failed");

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
                throw new Exception(e.Message);
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
