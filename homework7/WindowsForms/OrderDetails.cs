﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsForms
{
    public class OrderDetails : Order
    {
        public override void TakeOrder()
        {
            Console.WriteLine($"您的{product}下单成功，您的订单号为: {i}");
        }
        static uint i = 0;
        public string client;
        public uint num;
        public string product;
        public uint price;
        public uint Num {
            get { return num; }
            set { num = value; }
        }
        public string Client
        {
            get { return client; }
            set { client = value; }
        }
        public string Product
        {
            get { return product; }
            set { product = value; }
        }
        public uint Price {
            get { return price; }
            set { price = value; }
        }
        public OrderDetails(string client, string product)
        {
            this.client = client;
            this.product = product;
            this.num = i++;
            TakeOrder();
        }
        public OrderDetails() { }
        //public override string ToString()
        //{
        //    return $"商品:{Product}\t用户:{Client}\t订单号:{Num}\t价格:{Price}" ;
        //}

    }
}
