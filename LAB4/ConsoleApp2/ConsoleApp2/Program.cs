using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList mySL = new SortedList();
            mySL.Add("Third", "!");
            mySL.Add("Second", "World");
            mySL.Add("First", "Hello");

            Console.WriteLine("mySL");
            Console.WriteLine("Count:  {0}", mySL.Count);
            Console.WriteLine("Capacity: {0}", mySL.Capacity);
            Console.WriteLine(" key and valude:");

           
            List<Student> studentList = new List<Student>
            {
                new Student (1,"Alice"),
                new Student(2,"Bob"),
                new Student(3,"Charlie")
            };
            studentList.Add(new Student(4, "David"));
            studentList.Insert(1, new Student(5, "Eva"));
            studentList[2] = new Student(6, "Frank");


            Dictionary<string, int> ages = new Dictionary<string, int>();
            ages.Add("Alice", 25);
            ages.Add("Bob", 30);
            if(ages.ContainsKey("Alice"))
            {
                Console.WriteLine("Alice is" + ages["Alice"] + "years old.");
            }
            ages["Alice"] = 26;
            ages.Remove("Bob");
            foreach(var kvp in ages)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }  
        }
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Student(int id, string name)
            {
                Id = id;
                Name = name;
            }
            public override string ToString()
            {
                return $"Student (Id= {Id}, Name = {Name})";
            }
        }
        static void ListExample()
        {
            List<string> fruits = new List<string>();
            fruits.Add("Apple");
            fruits.Add("banan");
            fruits.Add("Cherry");
      
            fruits.Insert(1, "Blueberry");
            Console.WriteLine("Contains Banana? " + fruits.Contains("banan"));
            fruits[0] = "Avocado";
            fruits.Remove("Banana");
            fruits.RemoveAt(0);
            foreach (var fruit in fruits)
                Console.WriteLine(fruit);
        }
        static void QueueExample()
        {
            Queue<string> tasks = new Queue<string>();
            tasks.Enqueue("Downloand file");
            tasks.Enqueue("Scan file");
            Console.WriteLine("Next task:" + tasks.Peek());
            Console.WriteLine("Pricessing:" + tasks.Dequeue());
            
            foreach (var task in tasks)
                Console.WriteLine(task);
        }
        static void StackExample()
        {
            Stack<string> history= new Stack<string>();
            history.Push("page 1");
            history.Push("page 1");
            Console.WriteLine("Current page :"+ history.Peek());
            Console.WriteLine("Go back: " + history.Pop());

            foreach (var page in history)
                Console.WriteLine(page);
        }

    }
}
