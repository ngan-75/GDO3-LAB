using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static int hieu(int a,int b)
        {
            return a - b;
        }
        static int tong(int a,int b)
        {
            return a + b;
        }
        static float tich (int a,int b)
        {
            return a / b;
        }
        static int thuong(int a,int b)
        {
            return a * b;
        }
        
        static void Main(string[] args)
        {
            int a, b;
            Console.WriteLine("nhap so a");
            a = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("nhap so b");
            b = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("tong cua a va b:{0}", tong(a, b));
            Console.WriteLine("hieu cua a va b:{0}", hieu(a, b));
            Console.WriteLine("tich cua a va b:{0}", tich(a, b));
            Console.WriteLine("thuong cua a va b:{0}", thuong(a, b));
        }

    }
}
