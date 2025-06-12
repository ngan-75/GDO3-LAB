using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht01 = new Hashtable();
            ht01.Add("a", 1);
            ht01.Add("b", 2);
            ht01.Add("c", 3);
            ht01.Add("d", 4);
            ht01.Add("e", 5);
            ht01.Add(1, "c");
            //Hashtable.Remove: Xoa theo Key
            //ht01.Remove(1);
            bool hasKey = ht01.ContainsKey("c");
            if (hasKey) ht01.Remove("c");
            hasKey = ht01.ContainsKey("f");
            if (hasKey) ht01.Remove("f");

            bool hasValue = ht01.ContainsValue(3);
            hasValue = ht01.ContainsValue(6);


            foreach (DictionaryEntry item in ht01)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
                Console.WriteLine();
            }
            
            Console.ReadLine();
        }
    }
}
