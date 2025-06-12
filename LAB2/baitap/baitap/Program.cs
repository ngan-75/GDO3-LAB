using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("nhap 2 so nguyen x,y:");
            try
            {
                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());
                Console.WriteLine("ket qua cua bieu thuc= " + tinhgiatri(x, y));
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
            catch (NotNegativeException ex)
            {
                Console.WriteLine("NotNegativeException: " + ex.Message);
                Console.WriteLine("NotNegativeException:" + ex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception test :" + ex.Message);
                Console.WriteLine("Exception test :" + ex.StackTrace);
            }
            

        }
        public class NotNegativeException : Exception
        {
            public NotNegativeException(string message) : base(message)
            {
            }
        }
        static double tinhgiatri (int x,int y)
        {
            int tu=3*x+2*y;
            int mau=2*x-y;
            if (mau==0)
            {
                throw new DivideByZeroException("mau so bang 0");
            }
            double bieuthuc = tu / mau;
            if (bieuthuc<0)
            {
                throw new NotNegativeException("bieu thuc be hon khong");
            }
            return Math.Sqrt(bieuthuc);
        }
    }
}
