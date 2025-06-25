using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace delegate_demo
{
    internal class Program
    {
        class DelegateDemo
        {
            public delegate double Temperature(double temp);
            public static double FahrenheitToCelsius(double temp)
            {
                return ((temp - 32) / 9) * 5;
            }

            static void Main(string[] args)
            {
                Temperature tempConversion = new Temperature(FahrenheitToCelsius);
                double tempF = 96;
                double tempC = tempConversion(tempF);

                Console.WriteLine("Temperature in Fahrenheit = {0:F3}", tempF);
                Console.WriteLine("Temperature in Celsius = {0:F3}", tempC);
            }

        }
    }
}
