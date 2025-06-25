using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

delegate void MyDelegateVD00();
public delegate void MyDeleage(string s);
public delegate double Temperature(double temp);

public static class Program
{
    public static double FahrenheitToCelsius(double temp)
    {
        return ((temp - 32) / 9) * 5;
    }

    static void VD04_ShowTenCallback(MyDeleage callback)
    {
        Console.WriteLine("Nhập tên của bạn:");
        string name = Console.ReadLine();
        callback(name);
    }

    static void VD04()
    {
        MyDeleage ShowStringDelegate = new MyDeleage(ShowString);
        VD04_ShowTenCallback(ShowStringDelegate);
    }

    static void ShowString(string s)
    {
        Console.WriteLine("[ShowString] Your String: " + s);
    }

    delegate float tinhtoan2thamso(int a, int b);

    public static float Tinhcong(int a, int b)
    {
        return a + b;
    }

    delegate void Greet(string s);
    public delegate void Logger();

    class LogSytem
    {
        public static void LogToFile() => Console.WriteLine("ghi vao file");
        public static void LogToConsole() => Console.WriteLine("Hien thi console");
    }

    public delegate void Display();

    class Events
    {
        public event Display Print;
        public void Show()
        {
            Console.WriteLine("This is an event - driven program");
            Print?.Invoke();
        }
    }

    static void Swap(int a, int b)
    {
        int tam = a;
        a = b;
        b = tam;
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        tinhtoan2thamso ketqua = Tinhcong;
        float a = 5;
        float b = 10;
        float tong = ketqua(10, 5);
        Console.WriteLine("Tổng: " + tong);

        Greet sayhi = delegate (string name)
        {
            Console.WriteLine("Hi :{0}", name);
        };
        sayhi("Bob");

        Logger logger = LogSytem.LogToFile;
        logger += LogSytem.LogToConsole;
        logger();

        Events objEvents = new Events();
        objEvents.Print += () => Console.WriteLine("sự kiện đã được xử lý ");
        objEvents.Show();

        int counter = 0;
        Action increment = delegate { counter++; };
        increment();
        increment();
        Console.WriteLine(counter);

        Func<double, double, double> myFunc01 = delegate (double x, double y)
        {
            return x * y;
        };
        Console.WriteLine("Func Thuong :" + myFunc01?.Invoke(5, 10));

        Func<int, double, double> myFunc02 = delegate (int x, double y)
        {
            return x * y;
        };
        Console.WriteLine("Func Thuong :" + myFunc02?.Invoke(5, 10));

        Func<int, int, int> myFunc03 = (x, y) => x * y;
        int result = myFunc03(4, 5);
        Console.WriteLine("tich:" + result);

        Action<int> myAction02 = delegate (int num)
        {
            Console.WriteLine("Anonymous Hello World " + num);
        };
        myAction02?.Invoke(3);

        Action<double, double> myAction03 = delegate (double x, double y)
        {
            Console.WriteLine($"Tich {x}*{y}={x * y}");
        };
        myAction03?.Invoke(10, 5);

        Action<string> myAction04 = message =>
        Console.WriteLine("Tin nhan:" + message);
        myAction04("Chao ban!");

        Predicate<int> isEven = delegate (int number)
        {
            return number % 2 == 0;
        };

        List<int> number = new List<int> { 1, 2, 3, 4, 5 };
        List<int> evens = number.FindAll(isEven);

        foreach (int n in evens)
            Console.WriteLine(n);
        Console.ReadLine();
    }
}
