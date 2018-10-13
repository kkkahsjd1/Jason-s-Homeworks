using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Product
    {
        private uint price;
        private string goods;
        public string Goods{
            get {
                return goods ;
            }
            set {
                this.goods = value;
            }
            
        }
        public uint Price {
            get { return price; }
            set {
                if (value > 0)
                {
                    price = value;
                }
                else {
                    throw new ArgumentOutOfRangeException("price invalid!");
                }
            }
        }
        public Product(string goods, uint price)
        {
            this.price = price;
            this.goods = goods; 
        }
        public static List<Product> products = new List<Product>();
        public static void AddProducts(Product a)
        {
            if (a != null&&(!products.Contains(a)))
                products.Add(a);
            else {
                throw new ArgumentNullException("this products addition is invalid");
                 }

        }



    }
}
