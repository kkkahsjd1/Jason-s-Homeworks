using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class OrderDetails : Order
    {
        public override void TakeOrder()
        {
            Console.WriteLine($"您的{product}下单成功，您的订单号为: {i}");
        }
        static int i = 0;
        public string ClientName;
        public int OrderNum;
        public string product;
        public OrderDetails(string client, string product)
        {
            this.ClientName = client;
            this.product = product;
            this.OrderNum = i++;
            TakeOrder();
        }

    }
}
