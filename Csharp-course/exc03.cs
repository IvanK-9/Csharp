using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter number of rows (half of the diamond): ");
        int n = int.Parse(Console.ReadLine());

        // Upper half
        for (int i = 1; i <= n; i++)
        {
            Console.Write(new string(' ', n - i));
            Console.WriteLine(new string('*', 2 * i - 1));
        }

        // Lower half
        for (int i = n - 1; i >= 1; i--)
        {
            Console.Write(new string(' ', n - i));
            Console.WriteLine(new string('*', 2 * i - 1));
        }
    }
}