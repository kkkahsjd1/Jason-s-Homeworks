using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Database_Order
{
    public class Customer
    {
        public string PhoneNum {
            set;
            get;
        }
        public string Name {
            get;
            set;
        }
        public Customer(string name, string num)
        {
            string pattern = "^1[0-9]{10}$";
            if (Regex.IsMatch(num, pattern))
            {
                this.PhoneNum = num;
                this.Name = name;
            }
            else
                throw new Exception("电话号码格式有误");
        }

        
    }
}
