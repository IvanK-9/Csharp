using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json; // This works after installing the package via 'dotnet add package'

namespace MyApiProject
{
    internal class Program
    {
        // Modified Main to return a Task as per assignment requirements
        static async Task Main(string[] args)
        {
            string url = "https://mocki.io/v1/05f053a1-7b8d-46dd-80cb-c83685b3f3c9 "; // URL to fetch data from

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    // Fetch data from the internet
                    string jsonResponse = await httpClient.GetStringAsync(url);

                    // Deserialize the JSON text into a list of Root objects
                    var characters = JsonConvert.DeserializeObject<List<Root>>(jsonResponse);

                    // Print the results to the console
                    foreach (var character in characters)
                    {
                        Console.WriteLine($"Name: {character.name}");
                        Console.WriteLine($"City: {character.city}");
                        Console.WriteLine($"Age: {character.age}"); 
                        Console.WriteLine("----------------");
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

    // These classes were generated using json2csharp.com
    public class Root
    {
        public string name { get; set; }
        public string city { get; set; }
        public int age { get; set; }
        public string status { get; set; }
    }
}