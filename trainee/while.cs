namespace WhileIteration
{
    class Program
    {
        static void Main()
        {
            bool displayMenu = true;
            // While displayMenu is true, the program will return to the menu
            while (displayMenu)
            {
                displayMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Select an option:");
            Console.WriteLine("1) Play 'Guess the Number'");
            Console.WriteLine("2) Exit");
            string result = Console.ReadLine();

            if (result == "1")
            {
                GuessingGame();
                return true;
            }
            else if (result == "2")
            {
                return false; // This will end the while loop in Main method
            }
            else
            {
                return true;
            }
        }

        private static void GuessingGame()
        {
            Console.Clear();
            Console.WriteLine("Game 'Guess the Number'!");

            Random myRandom = new();
            int randomNumber = myRandom.Next(1, 11); // Generates a number from 1 to 10

            int guesses = 0;
            bool incorrect = true;

            // Loop continues while the user has NOT guessed the number
            while (incorrect)
            {
                Console.WriteLine("Guess a number from 1 to 10: ");
                string result = Console.ReadLine();
                guesses++;

                if (int.TryParse(result, out int guess) && guess == randomNumber)
                {
                    incorrect = false; // Condition changes, loop will break on next check
                }
                else
                {
                    Console.WriteLine("Wrong! Try again.");
                }
            }

            Console.WriteLine("Correct! You spent {0} attempts.", guesses);
            Console.ReadLine();
        }
    }
}