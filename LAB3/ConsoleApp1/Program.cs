using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList list01= new ArrayList();
            list01.Add(1);
            list01.Add(2);
            list01.Add(3);
            list01.Add(4);
            list01.Add(5);

            for (int i=0;i<list01.Count;i++)
            {
                Console.WriteLine($"Item {i}: {list01[i]}");
            }
            list01.RemoveAt(3);
            list01.Insert(4,10);
            list01.Insert(2, 8);
            Console.WriteLine($"List01 Count:{list01.Count}");
            ArrayList list02 = new ArrayList();
            list02.Add("a1");
            list02.Add("b1");
            list02.Add("c1");
            list02.Add("d1");
            list02[2] = "c2";
            list02.Add(100);
            list02.Add(3.14f);
            list01.InsertRange(4, list02);
            list01.InsertRange(6, list02);
            list02.Remove("c1");
            list02.Remove("c2");
            list02.Clear();

            list01.RemoveRange(6,5);
            for (int i = 0; i < list02.Count; i++)
            {
                Console.WriteLine($"List01 Count:{list02.Count}");
            }
            Console.ReadLine();

        }
    }
}
