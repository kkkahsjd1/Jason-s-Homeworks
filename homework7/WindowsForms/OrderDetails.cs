﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace WindowsForms
{
    public class OrderDetails : Order
    {
        //订单号判断
        public static bool Notest(string no)
        {
            string p1 = DateTime.Now.Year.ToString()+DateTime.Now.Month.ToString()+DateTime.Now.Day.ToString()+"[0-9]{3}";
            if (Regex.IsMatch(no, p1))
            {
                return true;
            }
            else
                return false;
            
        }
        public override void TakeOrder()
        {
            Console.WriteLine($"您的{product}下单成功，您的订单号为: {i}");
        }
        static uint i = 0;
        public string client;
        public uint num;
        public string product;
        public uint price;
        //电话号码
        public string PhoneNum {
            get;
            set;
        }
        //序列号
        public uint Num {
            get { return num; }
            set { num = value; }
        }
        //客户名
        public string Client
        {
            get { return client; }
            set { client = value; }
        }
        //商品名
        public string Product
        {
            get { return product; }
            set { product = value; }
        }
        //产品单价
        public uint Price {
            get { return price; }
            set { price = value; }
        }
        //产品数量
        public uint Amount {
            get;
            set;
        }
        //产品总价
        public uint Total {
            get { return Amount * Price; }
        }
        //订单号
        public string No
        {
            get;
            set;
        }
        public OrderDetails( string no,string product,uint amount)
        {
            //
            if (OrderDetails.Notest(no))
            {
                this.product = product;
                this.Amount = amount;
                this.num = i++;
                this.No = no;
                TakeOrder();
            }
            else
                Console.WriteLine("订单号有误");
        }
        public OrderDetails() { }
        public override string ToString()
        {
            return $"商品:{Product}\t用户:{Client}\t订单号:{Num}\t价格:{Price}";
        }

    }
}
