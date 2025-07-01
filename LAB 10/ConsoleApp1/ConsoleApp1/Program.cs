using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public class Customer
        {
            public string CustomerID { get; set; }
            public string ContactName { get; set; }
            public string City { get; set; }
        }
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Occupation { get; set; }


            public int Age { get; set; }
            public int CompanyId { get; set; }
        }


        public static List<Person> GenerateListOfPeople()
        {
            var people = new List<Person>();
            people.Add(new Person { FirstName = "Eric", LastName = "Fleming", Occupation = "Dev", Age = 24, CompanyId = 1, });
            people.Add(new Person { FirstName = "Steve", LastName = "Smith", Occupation = "Manager", Age = 40, CompanyId = 1 });
            people.Add(new Person { FirstName = "Brendan", LastName = "Enrick", Occupation = "Dev", Age = 30, CompanyId = 2 });
            people.Add(new Person { FirstName = "Jane", LastName = "Doe", Occupation = "Dev", Age = 35, CompanyId = 1 });
            people.Add(new Person { FirstName = "Samantha", LastName = "Jones", Occupation = "Dev", Age = 24, CompanyId = 2 });
            return people;
        }

        public class Company
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public static List<Company> GenerateCompanies()
        {
            return new List<Company> {
                new Company { Id = 1, Name = "Microsoft" },
                new Company { Id = 2, Name = "Google" },
                new Company { Id = 3, Name = "Apple" }
            };
        }

        public class FullName
        { 
            public string First { get; set; }
            public string Last { get; set; }
        }

        static void Main(string[] args)
        {
            List<Customer> MyCustomerList = new List<Customer>()
             { 
            new Customer{CustomerID = "ALFKI", ContactName = "Maria",City = "HCM" },
            new Customer{CustomerID = "ANATR", ContactName = "Ana", City = "HN"},
            new Customer{CustomerID = "ANTON", ContactName = "Antonio", City = "HN"}
            };
            var query = from c in MyCustomerList
                        where c.City == "HN"
                        select new { c.City, c.ContactName };
            foreach (var c in query)
                Console.WriteLine($"{c.ContactName} - {c.City}");

            // Sắp xếp danh sách số theo thứ tự tăng dần 
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            var sortedNumbers = list.OrderBy(n => n);
            foreach (var num in sortedNumbers)
            {
                Console.WriteLine(num);
            }

            // sắp xếp danh sách số theo thứ tự giảm dần 
            Console.WriteLine(" \nsap xep giam dan\n");
            var sortedDescNumbers = list.OrderByDescending(n => n);
            foreach (var num in sortedDescNumbers)
            {
                Console.WriteLine(num);
            }

            // nhóm dữ liệu 
            var groupedNumber = list.GroupBy(n => n % 2 == 0 ? "Even" : "Odd");

            foreach (var group in groupedNumber)
            {
                Console.WriteLine($"Group: {group.Key}");
                foreach (var num in group)
                {
                    Console.WriteLine(num);
                }
            }
            List<Person> people = GenerateListOfPeople();
            var companies = GenerateCompanies();
            // ket hop du lieu
            var peopleWithCompanies
               = people.Join(companies, Person => Person.CompanyId, Company => Company.Id,
                 (Person, Company) =>
                 new { Person.FirstName, Company.Name });
            var peopleWithCompaniesQuery = from p in people
                                           join c in companies on p.CompanyId equals c.Id
                                           select new {p.FirstName,c.Name};

            // liệt kê 
            var result = companies.GroupJoin(people,
                  Company => Company.Id,
                  Person => Person.CompanyId,
                  (Company, peopleInCompany)
                  => new
                  {
                      CompanyName = Company.Name,
                      Employees = peopleInCompany
                  });
            // tim kiem du lieu 
            var peopleOverTheAgeOf30 = people.Where(x => x.Age > 30);
            foreach(var p in peopleOverTheAgeOf30)
            {
                Console.WriteLine(p.Age);
            }

            IEnumerable<string> allFirstnames = people.Select(x => x.FirstName);
            foreach (var p in allFirstnames) Console.WriteLine(p);

            Person firstOrDefault = people.FirstOrDefault();
            Person firstThirtyYearOld = people.FirstOrDefault(x=> x.Age==30);
            Person willBeNull = people.FirstOrDefault(x => x.FirstName == "John");
            Person lastOrDefault = people.LastOrDefault();
            Person lastThirtyYearOld = people.LastOrDefault(x=> x.Age==30);
            Person singleEric = people.SingleOrDefault(x=>x.FirstName=="Eric");

            int nums = people.Count();
            int numOverf25 = people.Count(x => x.Age > 25);

            // true or false 
            bool thereArePeople = people.Any();
            bool anyDevsOver30 = people.Any(x => x.Occupation == "dev" && x.Age > 30);

            Console.WriteLine("true or false");
            Console.WriteLine("Có người nào không? " + thereArePeople);               
            Console.WriteLine("Có Dev nào trên 30 tuổi không? " + anyDevsOver30);

            // toList 

            List<Person> listOfDevs = 
                people.Where(x=> x.Occupation == "Dev")
                .ToList();
            // toArray
            Person[] arrayOfDevs = 
                people.Where(x=> x.Occupation == "Dev")
                .ToArray();
            // tinh toan

            int totalAge = people.Sum(p=> p.Age);
            double averageAge = people.Average(p=> p.Age);
            int youngestAge = people.Min(p=>  p.Age);
            string allNames = people.Aggregate("", (current, p) => current +p.FirstName + "");

            // ket hop nhieu phuong thuc 
            var Demo01 = people.Where(p=> p.Occupation == "Dev"&& p.Age>25)
                .OrderBy(p=> p.FirstName)
                .Select(p=> $"{p.FirstName} {p.LastName}")
                .ToList();
            Console.WriteLine("\n Dev co kinh nghiem sap xep theo ten");
            foreach (var name in Demo01)
            {
                Console.WriteLine($" - {name}");
            }
            // truy van 
             var PepleQuery = from p in people
                              select p;
            foreach (var p in PepleQuery)
            {
                Console.WriteLine($" - {p.FirstName}");
            }

            // truy van where

            var olderQuery = from p in people
                             where p.Age >=30
                             select p;
            foreach (var p in olderQuery) { Console.WriteLine($"- {p.FirstName}")};

            var PFullName = from p in people
                            let fullName = $"{p.FirstName} {p.LastName}"
                            where fullName.Contains("an")
                            orderby fullName
                            select new
                            {
                                p.FirstName,
                                p.LastName,
                                FullName = fullName
                            };
            foreach (var person in PFullName)
            {
                Console.WriteLine($"- {person.FullName}");
            }
            List<int> numbers = new List<int>() { 1, 3, 4, 5 };
            var doubleNumbers = from num in numbers
                                let doubled = num*2
                                where doubled >10
                                select new {Original = num , Double = doubled };
        }
    }
}
