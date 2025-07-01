using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitap_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>
            {
                12, -5, 0, 7, -14, 25, -1, 3, 8, -9,
                17, -22, 4, -3, 10, -6, 31, -17, 2, -8,
                19, -12, 0, 23, -30, 11, -7, 5, -15, 9,
                26, -18, 6, -4, 13, -2, 16, -20, 1, -10,
                28, -11, 14, -13, 15, -19, 18, -16, 21, -21
            };
            Console.WriteLine("cac so duong:");
            foreach (int so in numbers)
            {
                if (so > 0 && so >= 1 && so <= 12)
                { 
                    Console.WriteLine(so);
                }
            }
            Console.WriteLine("\nBinh phuong cac so lon hon 10:");
            foreach (int sol in numbers)
            {
                if (sol >10 )
                {
                    double kq = sol * sol;
                    Console.WriteLine(" Binh phuong cua:{0} = {1}",sol,kq);
                }
            }

            // cach Where

            var test = numbers.Where(x => x >= 1 && x <= 12);

            var testbp = numbers.Where(x => x > 10)
                .Select(x => new { x = x*x});

            
        }
    }
}
