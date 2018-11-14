using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WindowsForms
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
                Console.WriteLine("电话号码格式不正确");
        }

        
    }
}
