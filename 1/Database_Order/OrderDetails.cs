using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
namespace Database_Order
{
    public class OrderDetails : Order
    {
        //订单号判断
        
        public override void TakeOrder()
        {
            Console.WriteLine($"您的{Goods}下单成功，您的订单号为: {i}");
        }
        static uint i = 0;
        //电话号码
        public string PhoneNum {
            get;
            set;
        }
        //序列号
        public uint Num {
            get;
            set;
        }
        //客户名
        public string Client
        {
            get;
            set;
        }
        //商品名
        public string Goods
        {
            get;
            set;
        }
        //产品单价
        public uint Price {
            get;
            set;
        }
        //产品数量
        public uint Amount {
            get;
            set;
        }
        //产品总价
        public uint Total {
            get;
            set;
        }
        //订单号
        public string No
        {
            get;
            set;
        }
        public OrderDetails(string product,uint amount)
        {
            //
            this.Goods = product;
            this.Amount = amount;
            this.Num = i++;
            this.No = OrderService.Setnum();
            foreach (Product a in Product.GetProList())
            {
                if (a.Goods == product)
                {
                    this.Price =a.Price;        
                }
            }
            this.Total = Amount * Price;
            TakeOrder();
            
        }
        public OrderDetails() { }
        public override string ToString()
        {
            return $"商品:{Goods}\t用户:{Client}\t订单号:{Num}\t价格:{Price}";
        }

    }
}
