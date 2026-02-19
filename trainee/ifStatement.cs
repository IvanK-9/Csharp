using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Bobs giveaway");
        Console.Write("Choose a door (1, 2 or 3):  ");
        string userInput = Console.ReadLine();

        if (userInput == "1")
        {
            Console.WriteLine("You won a new car!");
        }
        else if (userInput == "2")
        {
            Console.WriteLine("You won a new boat!");
        }
        else if (userInput == "3")
        {
            Console.WriteLine("You won a new cat!");
        }
        else
        {
            Console.WriteLine("Sorry, we didn't understand that choice.");
        } // This closes the 'else'
    } // This closes the 'Main' method
} // This closes the 'Program' class