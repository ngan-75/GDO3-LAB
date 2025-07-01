using Firebase.Database;
using Firebase.Database.Query;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Program;



namespace ConsoleApp1
{
    internal class Program
    {
        public static async Task ReadTestData()
        {
            var firebase = new FirebaseClient("https://demogame01-adca2-default-rtdb.asia-southeast1.firebasedatabase.app/");
            var testData = await firebase.Child("test").OnceSingleAsync<TestData>(); 
            Console.WriteLine($"Message: {testData.Message}");
            Console.WriteLine($"Timestamp: {testData.Timestamp}");
        }

        public static async Task DeleteTestData()
        {
            var firebase = new FirebaseClient("https://demogame01-adca2-default-rtdb.asia-southeast1.firebasedatabase.app/");
            await firebase.Child("test").DeleteAsync();
            Console.WriteLine("Dữ liệu đã bị xoá khỏi Firebase");
        }

        static Player player = null;
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("\"C:\\Users\\KIM NGAN\\OneDrive\\Documents\\GitHub\\GDO3-LAB\\SEMI_FINAL\\FireBase Project\\ConsoleApp1\\demo.json\"")
            });

            while (true)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Nhập dữ liệu cho người chơi:");
                Console.WriteLine("2. Ghi dữ liệu vào Firebase");
                Console.WriteLine("3. Lấy dữ liệu từ Firebase");
                Console.WriteLine("4. Cập nhật dữ liệu");
                Console.WriteLine("5. Xoá dữ liệu");
                Console.WriteLine("6. Lưu top5 người có Gold cao nhất");
                Console.WriteLine("7. Lưu top5 người có Score cao nhất");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        player = NhapPlayer();
                        break;
                    case "2":
                        if (player != null) await SavePlayer(player);
                        else Console.WriteLine("Chưa có dữ liệu để ghi.");
                        break;
                    case "3":
                        await Showplayer();
                        break;
                    case "4":
                        await UpdatePlayer();
                        break;
                    case "5":
                        await DeletePlayer();
                        break;
                    case "6":
                        await SaveTop5Player();
                        break;
                    case "7":
                        await SaveTop5PlayerSroce();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            }
        }

        public class Player
        {
            public string PlayerID { get; set; }
            public string Name { get; set; }
            public int Gold { get; set; }
            public int Score { get; set; }
        }

        public class TestData
        {
            public string Message { get; set; }
            public string Timestamp { get; set; }
        }

        static Player NhapPlayer()
        {
            Console.Write("ID: ");
            string playerid = Console.ReadLine();
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Gold: ");
            int gold = int.Parse(Console.ReadLine());
            Console.Write("Score: ");
            int score = int.Parse(Console.ReadLine());

            return new Player { PlayerID = playerid, Name = name, Gold = gold, Score = score };
        }

        static FirebaseClient firebase = new FirebaseClient("https://demogame01-adca2-default-rtdb.asia-southeast1.firebasedatabase.app/");

        public static async Task SavePlayer(Player s)
        {
            await firebase.Child("Players").Child(s.PlayerID).PutAsync(s);
            Console.WriteLine("Đã lưu người chơi.");
        }

        public static async Task Showplayer()
        {
            var players = await firebase.Child("Players").OnceAsync<Player>();
            foreach (var s in players)
            {
                var data = s.Object;
                Console.WriteLine($"{data.PlayerID} - {data.Name} - {data.Gold} - {data.Score}");
            }
        }

        public static async Task UpdatePlayer()
        {
            Console.Write("Nhập PlayerID cũ cần cập nhật: ");
            string oldID = Console.ReadLine();

            Console.WriteLine("Nhập thông tin mới:");
            var newData = NhapPlayer();

            if (newData.PlayerID != oldID)
            {
                await firebase.Child("Players").Child(oldID).DeleteAsync();
                await firebase.Child("Players").Child(newData.PlayerID).PutAsync(newData);
            }
            else
            {
                await firebase.Child("Players").Child(oldID).PutAsync(newData);
            }

            Console.WriteLine("Đã cập nhật Player.");
        }

        public static async Task DeletePlayer()
        {
            Console.Write("Nhập ID cần xóa: ");
            string playerid = Console.ReadLine();
            await firebase.Child("Players").Child(playerid).DeleteAsync();
            Console.WriteLine("Đã xóa Player.");
        }

        public static async Task SaveTop5Player()
        {
            var myPlayer = await firebase.Child("Players").OnceAsync<Player>();

            var allPlayer = myPlayer
                .Select(s => new Player
                {
                    PlayerID = s.Object.PlayerID,
                    Name = s.Object.Name,
                    Gold = s.Object.Gold,
                    Score = s.Object.Score
                }).ToList();

            var topPlayer = allPlayer
                .OrderByDescending(s => s.Gold)
                .Take(5)
                .ToList();

            Console.WriteLine("\nTop 5 người có Gold cao nhất:");

            await firebase.Child("topGold").DeleteAsync();

            int index = 1;
            foreach (var s in topPlayer)
            {
                Console.WriteLine($"{s.Name} - {s.Gold} Gold");
                await firebase.Child("topGold").Child(index.ToString()).PutAsync(s);
                index++;
            }

            Console.WriteLine("\nĐã lưu top người chơi vào Firebase (node: topGold).");
        }
        public static async Task SaveTop5PlayerSroce()
        {
          
            var myPlayer = await firebase.Child("Players").OnceAsync<Player>();

            var allPlayer = myPlayer
                .Select(s => new Player
                {
                    PlayerID = s.Object.PlayerID,
                    Name = s.Object.Name,
                    Gold = s.Object.Gold,
                    Score = s.Object.Score 
                }).ToList();

            var topPlayer = allPlayer
                .OrderByDescending(s => s.Score)
                .Take(5)
                .ToList();

            Console.WriteLine("\nTop 5 người có Score cao nhất:");

            await firebase.Child("topScore").DeleteAsync();
            int index = 1;
            foreach (var s in topPlayer)
            {
                Console.WriteLine($"{index}.{s.PlayerID}-{s.PlayerID} - {s.Name} - {s.Gold} Gold - {s.Score} Score");
                var dataWithIndex = new
                {
                    Index = index,
                    PlayerID = s.PlayerID,
                    Name = s.Name,
                    Gold = s.Gold,
                    Score = s.Score

                };
                await firebase.Child("topScore").Child(s.PlayerID).PutAsync(dataWithIndex);
                index++;
            }
            Console.WriteLine("\nĐã lưu top người chơi vào Firebase (node: topScore).");
        }
    }
}


