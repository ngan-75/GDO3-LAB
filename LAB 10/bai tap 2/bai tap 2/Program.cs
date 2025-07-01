


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_tap_2
{
    internal class Program
    {
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Occupation { get; set; }
            public int Age { get; set; }
            public int CompanyId { get; set; }
        }
        public class Company
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public static List<Company> GenerateCompanies()
            {
                return new List<Company> {
                new Company { Id = 1, Name = "Microsoft" },
                new Company { Id = 2, Name = "Google" },
                new Company { Id = 3, Name = "Apple" }
                };
            }

            static void Main(string[] args)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                var companies = Company.GenerateCompanies();

                var peopletest = new List<Person>
                {
                            new Person { FirstName = "Eric", LastName = "Fleming", Occupation = "Dev", Age = 24, CompanyId = 1 },
                            new Person { FirstName = "Steve", LastName = "Smith", Occupation = "Manager", Age = 40, CompanyId = 1 },
                            new Person { FirstName = "Brendan", LastName = "Enrick", Occupation = "Dev", Age = 30, CompanyId = 2 },
                            new Person { FirstName = "Jane", LastName = "Doe", Occupation = "Dev", Age = 35, CompanyId = 1 },
                            new Person { FirstName = "Samantha", LastName = "Jones", Occupation = "Dev", Age = 24, CompanyId = 2 },
                            new Person { FirstName = "Tom", LastName = "Henderson", Occupation = "QA", Age = 28, CompanyId = 1 },
                            new Person { FirstName = "Anna", LastName = "Nguyen", Occupation = "HR", Age = 31, CompanyId = 3 },
                            new Person { FirstName = "Mark", LastName = "Tran", Occupation = "Dev", Age = 26, CompanyId = 1 },
                            new Person { FirstName = "Emily", LastName = "Clark", Occupation = "Manager", Age = 38, CompanyId = 2 },
                            new Person { FirstName = "John", LastName = "Phan", Occupation = "QA", Age = 29, CompanyId = 3 },
                            new Person { FirstName = "Chris", LastName = "Lee", Occupation = "Support", Age = 32, CompanyId = 2 },
                            new Person { FirstName = "Tina", LastName = "Vo", Occupation = "HR", Age = 36, CompanyId = 1 },
                            new Person { FirstName = "Alex", LastName = "Khan", Occupation = "Dev", Age = 23, CompanyId = 3 },
                            new Person { FirstName = "Natalie", LastName = "Wang", Occupation = "Manager", Age = 41, CompanyId = 2 },
                            new Person { FirstName = "Brian", LastName = "Hoang", Occupation = "Dev", Age = 27, CompanyId = 1 },
                            new Person { FirstName = "Lucy", LastName = "Kim", Occupation = "Dev", Age = 29, CompanyId = 3 },
                            new Person { FirstName = "Victor", LastName = "Ng", Occupation = "DevOps", Age = 33, CompanyId = 2 },
                            new Person { FirstName = "Rachel", LastName = "Ly", Occupation = "QA", Age = 30, CompanyId = 1 },
                            new Person { FirstName = "Tommy", LastName = "Pham", Occupation = "Support", Age = 27, CompanyId = 3 },
                            new Person { FirstName = "Jasmine", LastName = "Le", Occupation = "Dev", Age = 24, CompanyId = 1 },
                            new Person { FirstName = "Daniel", LastName = "Nguyen", Occupation = "Dev", Age = 26, CompanyId = 2 },
                            new Person { FirstName = "Linda", LastName = "Ngoc", Occupation = "HR", Age = 39, CompanyId = 3 },
                            new Person { FirstName = "Peter", LastName = "Lam", Occupation = "QA", Age = 35, CompanyId = 1 },
                            new Person { FirstName = "Sophia", LastName = "Dao", Occupation = "Manager", Age = 42, CompanyId = 2 },
                            new Person { FirstName = "Albert", LastName = "Vo", Occupation = "Dev", Age = 25, CompanyId = 3 },
                            new Person { FirstName = "Mia", LastName = "Pham", Occupation = "Dev", Age = 23, CompanyId = 2 },
                            new Person { FirstName = "Nathan", LastName = "Do", Occupation = "Support", Age = 34, CompanyId = 1 },
                            new Person { FirstName = "Karen", LastName = "Tran", Occupation = "QA", Age = 28, CompanyId = 3 },
                            new Person { FirstName = "Henry", LastName = "Bui", Occupation = "DevOps", Age = 31, CompanyId = 2 },
                            new Person { FirstName = "Lily", LastName = "Mai", Occupation = "Manager", Age = 43, CompanyId = 1 },
                            new Person { FirstName = "Dylan", LastName = "Nguyen", Occupation = "Dev", Age = 30, CompanyId = 3 },
                            new Person { FirstName = "Isabella", LastName = "Pham", Occupation = "Dev", Age = 26, CompanyId = 2 },
                            new Person { FirstName = "Jason", LastName = "Le", Occupation = "Support", Age = 29, CompanyId = 1 },
                            new Person { FirstName = "Cindy", LastName = "Vo", Occupation = "QA", Age = 27, CompanyId = 3 },
                            new Person { FirstName = "Kevin", LastName = "Tran", Occupation = "Dev", Age = 28, CompanyId = 2 },
                            new Person { FirstName = "Amy", LastName = "Lam", Occupation = "Manager", Age = 37, CompanyId = 1 },
                            new Person { FirstName = "Sean", LastName = "Hoang", Occupation = "DevOps", Age = 32, CompanyId = 3 },
                            new Person { FirstName = "Nina", LastName = "Huynh", Occupation = "HR", Age = 33, CompanyId = 2 },
                            new Person { FirstName = "Tony", LastName = "Ngoc", Occupation = "Dev", Age = 25, CompanyId = 1 },
                            new Person { FirstName = "Grace", LastName = "Nguyen", Occupation = "Dev", Age = 26, CompanyId = 3 },
                            new Person { FirstName = "David", LastName = "Ly", Occupation = "Support", Age = 30, CompanyId = 2 },
                            new Person { FirstName = "Olivia", LastName = "Pham", Occupation = "Dev", Age = 24, CompanyId = 1 },
                            new Person { FirstName = "Ethan", LastName = "Le", Occupation = "QA", Age = 28, CompanyId = 3 },
                            new Person { FirstName = "Ashley", LastName = "Truong", Occupation = "Dev", Age = 22, CompanyId = 2 },
                            new Person { FirstName = "Tyler", LastName = "Kim", Occupation = "Manager", Age = 39, CompanyId = 1 },
                            new Person { FirstName = "Luna", LastName = "Vo", Occupation = "DevOps", Age = 34, CompanyId = 3 },
                            new Person { FirstName = "Zack", LastName = "Nguyen", Occupation = "Dev", Age = 27, CompanyId = 2 },
                            new Person { FirstName = "Bella", LastName = "Pham", Occupation = "Support", Age = 31, CompanyId = 1 }
                };
                // cau 1
                var loc = peopletest
                    .Where(p=>p.Age<30&&p.Occupation== "Dev"&& p.FirstName.StartsWith("T"))
                    .ToList();
                Console.WriteLine("Những người dưới 30 tuổi làm Dev có tên bắt đầu bằng T");
               foreach (var p in loc)
                {
                    Console.WriteLine("FirstName: {0} - LastName:{1}", p.FirstName, p.LastName);

                }
                // cau 2

                var sorted = peopletest.OrderBy(p => p.FirstName).ThenBy(p => p.Age).ToList();
                Console.WriteLine("\n2. Sắp xếp theo tên và tuổi:");
                foreach (var p in sorted)
                    Console.WriteLine($"{p.FirstName} {p.LastName} - {p.Age}");
                // cau 3

                var grouped = peopletest
                .GroupBy(p => p.Occupation)
                .Select(g => new { Job = g.Key, Count = g.Count() })
                .ToList();
                Console.WriteLine("\n3. Nhóm theo nghề nghiệp:");
                foreach (var g in grouped)
                    Console.WriteLine($"{g.Job}: {g.Count}");

                //cau 4
               
                var youngest = peopletest.Min(p => p.Age);
                var oldest = peopletest.Max(p => p.Age);
                var totalAge = peopletest.Sum(p => p.Age);
                Console.WriteLine($"\n4. Tuổi nhỏ nhất: {youngest}, lớn nhất: {oldest}, tổng tuổi: {totalAge}");



                // cau 5
                var managers = peopletest
                .Where(p => p.Occupation == "Manager")
                .Select(p => new { Name = $"{p.FirstName} {p.LastName}", p.Age })
                .ToList();
                Console.WriteLine("\n5. Danh sách Manager:");
                foreach (var m in managers)
                    Console.WriteLine($"{m.Name} - Age: {m.Age}");

                // cau 6
                var msId = companies.First(c => c.Name == "Microsoft").Id;
                var msManagers = peopletest
                    .Where(p => p.Occupation == "Manager" && p.CompanyId == msId)
                    .ToList();
                Console.WriteLine("\n6. Manager tại Microsoft:");
                foreach (var p in msManagers)
                    Console.WriteLine($"{p.FirstName} {p.LastName} - Age: {p.Age}");

                // cau 7
                var topDevCompany = peopletest
               .Where(p => p.Occupation == "Dev")
               .GroupBy(p => p.CompanyId)
               .OrderByDescending(g => g.Count())
               .First();

                var companyName = companies.First(c => c.Id == topDevCompany.Key).Name;
                Console.WriteLine($"\n7. Công ty có nhiều Dev nhất: {companyName} ({topDevCompany.Count()} Devs)");
            }
        }
    }
}
