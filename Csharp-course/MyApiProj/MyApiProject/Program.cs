using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyApiProject
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://mocki.io/v1/f21298ee-1c53-4ff5-ac61-0578ac05f688";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    string jsonResponse = await httpClient.GetStringAsync(url);
                    var characters = JsonConvert.DeserializeObject<List<Root>>(jsonResponse);

                    Console.WriteLine("Characters from API:");
                    foreach (var character in characters)
                    {
                        Console.WriteLine($"Name: {character.name}, City: {character.city}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
            Console.WriteLine("Done. Press any key...");
            Console.ReadKey();
        }
    }

    public class Root
    {
        public string name { get; set; }
        public string city { get; set; }
    }
}