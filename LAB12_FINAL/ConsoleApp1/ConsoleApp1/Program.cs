using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Firebase.Database;
using Firebase.Database.Query;
using System.Windows.Forms;
using System.ComponentModel;
namespace ConsoleApp1
{
    internal class Program
    {
        public class Player
        {
            public string Name { get; set; }
            public int Level { get; set; }
            public bool IsActive { get; set; }
            public int VipLevel { get; set; }
            public int Gold { get; set; }
            public DateTime LastLogin { get; set; }
        }

        static FirebaseClient firebase = new FirebaseClient("https://lab12-357a8-default-rtdb.asia-southeast1.firebasedatabase.app/");

        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            List<Player> players = null;

            try
            {
                string json = await client.GetStringAsync("https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/refs/heads/main/lab12_players.json");
                players = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Player>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tải hoặc đọc JSON: " + ex.Message);
                return;
            }

            Console.WriteLine("--Danh sach nguoi choi khong hoat dong gan day--");
            DateTime now = new DateTime(2025, 06, 30, 0, 0, 0);
            var nguoichoi = players
                .Where(p => !p.IsActive || (now - p.LastLogin).TotalDays > 5)
                .ToList();

            int index = 1;
            foreach (var p in nguoichoi)
            {
                Console.WriteLine("Ten: {0}, IsActive: {1}, LastLogin: {2}", p.Name, p.IsActive, p.LastLogin);
                var newIndex = new
                {
                    p.IsActive,
                    p.LastLogin,
                    p.Name
                };
                await firebase
                    .Child("final_exam_bai1_inactive_players")
                    .Child(index.ToString())
                    .PutAsync(newIndex);
                ++index;
            }

            Console.WriteLine("---Tat ca nguoi choi co Level duoi 10---");
            var nguoichoi2 = players
                .Where(p => p.Level < 10)
                .ToList();

            int index2 = 1;
            foreach (var p in nguoichoi2)
            {
                Console.WriteLine("Ten: {0}, Level: {1}, Gold: {2}", p.Name, p.Level, p.Gold);
                var newindex2 = new
                {
                    p.Name,
                    p.Level,
                    CurrentGold = p.Gold,
                };
                await firebase
                    .Child("final_exam_bai1_low_level_players")
                    .Child(index2.ToString())
                    .PutAsync(newindex2);
                ++index2;
            }
            Console.WriteLine("--Top 3 nguoi choi co VIP cao nhat--");
            var vipTop3 = players
              .Where(p => p.VipLevel > 0)
              .OrderByDescending(p => p.Level)
              .ThenByDescending(p => p.Gold)
              .Take(3)
              .Select((p, i) => new
              {
                  p.Name,
                  p.VipLevel,
                  p.Level,
                  CurrentGold = p.Gold,
                  AwardedGlodAmount = i == 0 ? 2000 : i == 1 ? 1500 : 1000
               })
              .ToList();


            int index3 = 1; 
            foreach (var p in vipTop3)
            {
                Console.WriteLine($"Ten: {p.Name}, Level: {p.Level}, Gold: {p.CurrentGold}, Thuong: {p.AwardedGlodAmount}");

                var data = new
                {
                    p.Name,
                    p.Level,
                    CurrentGold = p.CurrentGold,
                    AwardedGlodAmount = p.AwardedGlodAmount
                };
                await firebase
                    .Child("final_exam_bai2_top3_vip_awards")
                    .Child(index3.ToString())
                    .PutAsync(data);
                index3++;
            }
        }


    }
}

