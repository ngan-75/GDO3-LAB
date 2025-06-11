using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("nhap hai so a,b");
            int[] array = { 1, 2, 3 };
            Console.WriteLine("Array[3]= " + array[2]);
            for (int i=0;i<=3;i++)
            {
                Console.WriteLine($"Array[{i}] = {array[2]}");
            }
            try
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                if (b==0)
                {
                    Console.WriteLine("loi b=0");
                    throw new Exception("Input loi b=0");
                }
                Console.WriteLine("Thuong la:{0}", thuong(a, b));
                throw new Exception();

            }
            catch(FormatException ex)
            {
                Console.WriteLine("FormatException:" + ex.Message);
                Console.WriteLine("FormatException:" + ex.StackTrace);
            }
             catch(DivideByZeroException ex)
            {
                            Console.WriteLine("DivideByZeroException: " + ex.Message);
                            Console.WriteLine("DivideByZeroException: " + ex.StackTrace);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception test :" + ex.Message);
                Console.WriteLine("Exception test :" + ex.StackTrace);
            }
        
            finally
            {
                Console.WriteLine("finally:");
            };
            Console.WriteLine("Press any key to exit");

        }
        static float thuong (float a,int b)
        {
            return a / b;

        }
        static void CauseFormatException ()
        {
            string s = "hello World!";
        }
    }
}
