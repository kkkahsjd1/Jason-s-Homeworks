using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;

namespace Program1
{

    public class ClockEventArgs : EventArgs { }
    public delegate void ClockEventHandler(object sender, ClockEventArgs e);
    public class Clock
    {
        public event ClockEventHandler alarmClock;
        public void DoClock()
        {
            if (alarmClock != null)
            {
                ClockEventArgs args = new ClockEventArgs();
                alarmClock(this, args);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please set your time clock:  h  min");
            string r = Console.ReadLine();
            string []time = new string[2];
            Boolean ok = true;
            do
            {
                try
                {
                    time = Regex.Split(r, " ", RegexOptions.IgnoreCase);
                    while (Convert.ToInt32(time[0]) < 0 || Convert.ToInt32(time[0]) >= 24 || Convert.ToInt32(time[1]) < 0 || Convert.ToInt32(time[1]) >= 60)
                    {
                        Console.WriteLine("Data Error,please set again:");
                        r = Console.ReadLine();
                        time = Regex.Split(r, " ", RegexOptions.IgnoreCase);
                    }

                }
                catch (Exception e)
                {
                    ok = false;
                    Console.WriteLine("Data Error,please set again:");
                    r = Console.ReadLine();
                } 
            } while (ok = !ok);
            var clock = new Clock();
            string t = time[0]+ ":"+time[1];
            while (DateTime.Now.ToString("t") != t)
            {
                Thread.Sleep(5000);//五秒重复检测一次
                
            }
            Console.WriteLine("It's " + t + "now !");
            
            clock.alarmClock += Ring;
            clock.DoClock();
        }
        static void Ring(object sender, ClockEventArgs e)
        {
            Console.WriteLine("it's time to get up!!!");
        }
    }
}
