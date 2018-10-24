using Microsoft.VisualStudio.TestTools.UnitTesting;
using program1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        public static void Originalize()
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
        }
        [TestMethod()]
        public void AddOrderTest1()
        {
            Product.AddProducts(new Product("华硕FX80GM-飞行堡垒星途版", 13000));
            OrderService.AddOrder(new OrderDetails("lry", "华硕FX80GM-飞行堡垒星途版"));
            Assert.IsTrue(OrderService.GetList()[0].client == "lry" && OrderService.GetList()[0].product == "华硕FX80GM-飞行堡垒星途版" && OrderService.GetList()[0].price == 13000);
        }
        [TestMethod()]
        public void AddOrderTest2()
        {
            Product.AddProducts(new Product("华硕FX80GM-飞行堡垒星途版", 13000));
            OrderService.AddOrder(new OrderDetails("lol", "华硕FX80GM-飞行堡垒星途版"));
            Assert.IsTrue(OrderService.GetList()[0].client == "lry" && OrderService.GetList()[0].product == "华硕FX80GM-飞行堡垒星途版" && OrderService.GetList()[0].price == 13000);
        }
        [TestMethod()]
        public void SeekByNameTest1()
        {
            OrderServiceTests.Originalize();
            Assert.IsTrue(OrderService.SeekByName("lry").client == "lry" && OrderService.SeekByName("lry").product == "华硕FX80GM-飞行堡垒星途版" && OrderService.SeekByName("lry").price == 13000);
        }
        [TestMethod()]
        public void SeekByNameTest2()
        {
            OrderServiceTests.Originalize();
            Assert.IsTrue(OrderService.SeekByName("lry").client == "lry" && OrderService.SeekByName("lry").product == "华硕FX80GM-飞行堡垒星途版" && OrderService.SeekByName("lry").price == 13000);
        }
        [TestMethod()]
        public void SeekByNumTest1()
        {
            OrderServiceTests.Originalize();
            Assert.IsTrue(OrderService.SeekByNum(4).client == "lry" && OrderService.SeekByNum(4).product == "华硕FX80GM-飞行堡垒星途版" && OrderService.SeekByNum(4).price == 13000 && OrderService.SeekByNum(4).num == 4);
        }
        [TestMethod()]
        public void SeekByNumTest2()
        {
            OrderServiceTests.Originalize();
            Assert.IsTrue(OrderService.SeekByNum(4).client == "lry" && OrderService.SeekByNum(4).product == "华硕FX80GM-飞行堡垒星途版" && OrderService.SeekByNum(4).price == 13000 && OrderService.SeekByNum(4).num == 4);
        }
        [TestMethod()]
        public void SeekByProductTest1()
        {
            OrderServiceTests.Originalize();
            Assert.IsTrue(OrderService.SeekByProduct("华硕FX80GM-飞行堡垒星途版").client == "lry" && OrderService.SeekByProduct("华硕FX80GM-飞行堡垒星途版").product == "华硕FX80GM-飞行堡垒星途版" && OrderService.SeekByProduct("华硕FX80GM-飞行堡垒星途版").price == 13000 && OrderService.SeekByProduct("华硕FX80GM-飞行堡垒星途版").num == 4);
        }
        [TestMethod()]
        public void SeekByProductTest2()
        {
            OrderServiceTests.Originalize();
            Assert.IsTrue(OrderService.SeekByProduct("华硕FX80GM-飞行堡垒星途版").client == "lry" && OrderService.SeekByProduct("华硕FX80GM-飞行堡垒星途版").product == "华硕FX80GM-飞行堡垒星途版" && OrderService.SeekByProduct("华硕FX80GM-飞行堡垒星途版").price == 13000 && OrderService.SeekByProduct("华硕FX80GM-飞行堡垒星途版").num == 4);
        }

        [TestMethod()]
        public void DeleteAsNameTest1()
        {
            OrderServiceTests.Originalize();
            OrderService.DeleteAsName("lry");
            Assert.IsTrue(OrderService.GetList().Find(a => a.client == "lry")==null);
        }
        [TestMethod()]
        public void DeleteAsNameTest2()
        {
            OrderServiceTests.Originalize();
            OrderService.DeleteAsName("lry");
            Assert.IsTrue(OrderService.GetList().Find(a => a.client == "ljj") == null);
        }
        [TestMethod()]
        public void DeleteAsNumTest1()
        {
            OrderServiceTests.Originalize();
            OrderService.DeleteAsNum(0);
            Assert.IsTrue(OrderService.GetList().Find(a => a.num == 0 ) == null);
        }
        [TestMethod()]
        public void DeleteAsNumTest2()
        {
            OrderServiceTests.Originalize();
            OrderService.DeleteAsNum(0);
            Assert.IsTrue(OrderService.GetList().Find(a => a.num == 1) == null);
        }
        [TestMethod()]
        public void ChangeTest1()
        {
            OrderServiceTests.Originalize();
            OrderService.Change(OrderService.GetList()[1], OrderService.GetList()[4]);
            Assert.IsTrue(OrderService.GetList()[1].num==4);
        }
        [TestMethod()]
        public void ChangeTest2()
        {
            OrderServiceTests.Originalize();
            OrderService.Change(OrderService.GetList()[1], OrderService.GetList()[3]);
            Assert.IsTrue(OrderService.GetList()[1].num == 4);
        }
    }
}