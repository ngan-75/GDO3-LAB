using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack myStack = new Stack();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);
            var a = myStack.Pop();
            var b = myStack.Peek();
            myStack.Clear();
            bool has2 = myStack.Contains(2);
            bool hasz= myStack.Contains("z");
            Queue myqueue01 = new Queue();
            myqueue01.Enqueue(1);
            myqueue01.Enqueue(2);
            myqueue01.Enqueue(3);
            myqueue01.Enqueue(4);
            myqueue01.Enqueue(5);
            myqueue01.Enqueue(5);
            myqueue01.Enqueue(5);
            myqueue01.Enqueue("Bob");
            myqueue01.Enqueue("tom");
            myqueue01.Enqueue("Jerry");
            var item01 = myqueue01.Dequeue();
            Console.WriteLine("Contain 5 in Quene :" + myqueue01.Contains(5));
            Console.WriteLine("Contain 10 in Quene :" + myqueue01.Contains(10));
            Console.WriteLine("Size of Stack:" + myqueue01.Count );

            Console.ReadLine();
        }
    }
}
