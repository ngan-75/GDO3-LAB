using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Firebase.Database;
using Firebase.Database.Query;
using static Bai_1.Program;
using System.Windows.Forms;

namespace Bai_1
{
    internal class Program
    {
       private static readonly HttpClient client = new HttpClient();
       
        public class Player 
        {
            public string name { get; set; }
            public int Gold { get; set; }
            public int Coins { get; set; }
            public int VipLevel { get; set; }
            public string Region { get; set; }
            public DateTime LastLogin { get; set; }



        }
        static FirebaseClient firebase = new FirebaseClient("https://lab11-7f8b6-default-rtdb.asia-southeast1.firebasedatabase.app/");
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            List<Player> player = null;
            try
            {
                string json = await client.GetStringAsync("https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/main/simple_players.json");
                player = JsonConvert.DeserializeObject<List<Player>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tải hoặc đọc JSON: {ex.Message}");
                return;
            }
            var richPlayer = player 
                .Where(p=> p.Gold>1000&&  p.Coins > 100)
                .OrderByDescending(p=> p.Coins)
                .Select(p=> new {p.name,p.Gold,p.Coins})
                .ToList();
            foreach (var p in richPlayer)
            {
                Console.WriteLine("Ten: {0}, Gold: {1}, Coins: {2}", p.name, p.Gold, p.Coins);
            }
           foreach (var p in richPlayer)
           {
                await firebase
                    .Child("quiz_bai1_richPlayers")
                    .Child(p.name)
                    .PutAsync(p);
                Console.WriteLine("Da day len FireBase");
           }

           // cau 2
            int totalVip = player.Count(p => p.VipLevel > 0);
            Console.WriteLine("Tong so nguoi choi Vip: {0}",totalVip);
            var viptheokhuvuc = player
                .Where(p => p.VipLevel > 0)
                .GroupBy(p => p.Region)
                .Select(g => new { Region = g.Key, Count = g.Count() })
                .ToList();
            Console.WriteLine("So luong nguoi choi Vip theo khu vuc");
            foreach (var v in viptheokhuvuc)
            {
                Console.WriteLine("Khu vuc: {0}, so nguoi choi Vip: {1}", v.Region, v.Count);
            }
            DateTime now = new DateTime(2025, 06, 30, 0, 0, 0);
            var nguoichoi = player
                .Where(p => p.VipLevel > 0 && (now - p.LastLogin).TotalDays <= 2)
                .Select(p => new
                {
                    p.name,
                    p.VipLevel,
                    p.LastLogin
                })
                .ToList();
            Console.WriteLine("Nhung nguoi choi dang nhap gan day");
            foreach (var p in nguoichoi)
            {
                Console.WriteLine("Ten: {0}, Vip Level: {1}, So lan dang nhap: {2}", p.name, p.VipLevel, p.LastLogin);
            }
            foreach (var p in nguoichoi)
            {
                await firebase
                    .Child("quiz_bai2_recentVipPlayers")
                    .Child(p.name)
                    .PutAsync(p);
                Console.WriteLine(" da day len firebase");
            }
        }
    }
}
