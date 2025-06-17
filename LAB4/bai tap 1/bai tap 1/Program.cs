using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_tap_1
{
    internal class Program
    {
        public static void RamdomNum (int num)
        {
            Console.WriteLine("Valude: ", num);
            Random random = new Random((int) DateTime.Now.Ticks);
            for (int i = 0; i < num; i++)
            {
                int value = random.Next(100);
                Console.WriteLine(value + "");

            }
        }
        static void Main(string[] args)
        {
            Console.Write("Nhap so lupng phan tu n: ");
            int n = int.Parse(Console.ReadLine());

            List<int> daySo = new List<int>();
            Random rd = new Random();

            for (int i = 0; i < n; i++)
            {
                int so = rd.Next(100);
                daySo.Add(so);
            }

            daySo.Sort(); 

            Console.WriteLine("Day sao khi sap xep tang dan:");
            foreach (int so in daySo)
            {
                Console.Write(so + " ");
            }
        }
    }
}
