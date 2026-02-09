using System;

class Program
{
    static void Main()
    {
        // Ask for the user's first name
        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine();


        // Ask for the user's last name
        Console.Write("Enter your last name: ");
        string lastName = Console.ReadLine();


        // Say hello using both names
        Console.WriteLine("Hello " + firstName + " " + lastName + "!");


        // Keep the program open so the user can see the message
        Console.WriteLine("\nPress any key to close...");
        Console.ReadKey();
    }
}
