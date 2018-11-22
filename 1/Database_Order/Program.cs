using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mysql.Data.MysqlClient;

namespace Database_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer("lry", "13092787491");
            Customer customer2 = new Customer("ljh", "13274574319");
            Customer customer3 = new Customer("lgr", "13092783343");
            Product.AddProducts(new Product("banana", 20));
            Product.AddProducts(new Product("apple", 29));
            Product.AddProducts(new Product("computer", 8939));
            Product.AddProducts(new Product("laptop", 12050));
            Product.AddProducts(new Product("earphone", 130));
            OrderDetails a1 = new OrderDetails("banana", 7);
            OrderService.AddOrder(customer1, a1);
            OrderDetails a2 = new OrderDetails("apple", 2);
            OrderService.AddOrder(customer1, a2);
            OrderDetails a3 = new OrderDetails("computer", 3);
            OrderService.AddOrder(customer2, a3);
            OrderDetails a4 = new OrderDetails("laptop", 5);
            OrderService.AddOrder(customer3, a4);
            OrderDetails a5 = new OrderDetails("earphone", 6);
            OrderService.AddOrder(customer3, a5);
            
        }
    }
}
