using System;

class FibonacciProgram
{
    static void Main()
    {
        Console.WriteLine("Print to screen: Display the n number Fibonacci series\n");
        
        char continueChoice;
        
        do
        {
            // Ask the user to input number of Fibonacci Series
            Console.Write("Ask the user to Input number of Fibonacci Series: ");
            string input = Console.ReadLine();
            
            // Check if input is integer
            if (!int.TryParse(input, out int n))
            {
                Console.WriteLine("There is an error, input integer\n");
                continue;
            }
            
            // Validate that n is positive
            if (n <= 0)
            {
                Console.WriteLine("There is an error, input integer\n");
                continue;
            }
            
            // Display the Fibonacci series
            DisplayFibonacciSeries(n);
            
            // Ask user if they want to create a new series
            Console.Write("\nAsk user Do you want to create a new series? Yes (y) No (Enter): ");
            string choice = Console.ReadLine();
            
            continueChoice = string.IsNullOrEmpty(choice) ? 'n' : char.ToLower(choice[0]);
            Console.WriteLine();
            
        } while (continueChoice == 'y');
        
        Console.WriteLine("Close program");
    }
    
    // Function to display the n number Fibonacci series
    static void DisplayFibonacciSeries(int n)
    {
        Console.WriteLine("\nPrint series of Fibonacci numbers to screen:");
        
        if (n == 1)
        {
            Console.Write("0");
        }
        else if (n == 2)
        {
            Console.Write("0, 1");
        }
        else
        {
            long first = 0, second = 1;
            Console.Write($"{first}, {second}");
            
            for (int i = 3; i <= n; i++)
            {
                long next = first + second;
                Console.Write($", {next}");
                first = second;
                second = next;
            }
        }
        
        Console.WriteLine();
    }
}