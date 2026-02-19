using System;

class ArraysTraining
{
    static void Main()
    {
        int[] numbers = new int[] { 1, 2, 3, 4, 5 };

        numbers [0] = 4;
        numbers [1] = 8;
        numbers [2] = 15;
        numbers [3] = 16;
        numbers [4] = 23;

        Console.WriteLine(numbers[0]);
        Console.WriteLine(numbers.Length);
  
        Console.ReadLine();
    }
}