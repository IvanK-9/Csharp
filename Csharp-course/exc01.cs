using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string continueChoice;
        
        do
        {
            // Get first sentence from user
            Console.WriteLine("Enter the first sentence:");
            string sentence1 = Console.ReadLine();
            
            // Get second sentence from user
            Console.WriteLine("Enter the second sentence:");
            string sentence2 = Console.ReadLine();
            
            // Split sentences into words and compare
            string[] words1 = sentence1.Split(new[] { ' ', '.', ',', '!', '?' }, 
                                             StringSplitOptions.RemoveEmptyEntries);
            string[] words2 = sentence2.Split(new[] { ' ', '.', ',', '!', '?' }, 
                                             StringSplitOptions.RemoveEmptyEntries);
            
            // Check if any words match (case-insensitive)
            bool hasCommonWord = words1.Any(word1 => 
                words2.Any(word2 => word1.Equals(word2, StringComparison.OrdinalIgnoreCase)));
            
            // Display result
            if (hasCommonWord)
            {
                Console.WriteLine("The substring exists in the string");
            }
            else
            {
                Console.WriteLine("The substring does not exist in the string");
            }
            
            // Ask to continue with error handling
            do
            {
                Console.WriteLine("\nDo you want to continue? (y/n):");
                continueChoice = Console.ReadLine()?.ToLower();
                
                if (continueChoice != "y" && continueChoice != "n")
                {
                    Console.WriteLine("Invalid input! Please enter only 'y' or 'n'.");
                }
            } while (continueChoice != "y" && continueChoice != "n");
            
            Console.WriteLine(); // Add spacing between iterations
            
        } while (continueChoice == "y");
        
        Console.WriteLine("Program ended. Press any key to exit...");
        Console.ReadKey();
    }
}