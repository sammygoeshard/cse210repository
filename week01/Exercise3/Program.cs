
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Guess My Number (1–100) ===");
        Console.WriteLine("I have a number in mind. Try to guess it!");

        Random rng = new Random();

        // Outer loop to play multiple rounds
        bool keepPlaying = true;
        while (keepPlaying)
        {
            int magic = rng.Next(1, 101); // 1–100 inclusive
            int guessCount = 0;
            int guess = int.MinValue;

            // Inner loop: single round until user guesses correctly
            while (guess != magic)
            {
                Console.Write("What is your guess? ");

                // Input validation
                if (!int.TryParse(Console.ReadLine(), out guess))
                {
                    Console.WriteLine("Please enter a whole number between 1 and 100.");
                    continue;
                }

                // (Optional) clamp/range check message
                if (guess < 1 || guess > 100)
                {
                    Console.WriteLine("Stay within 1–100, please.");
                    continue;
                }

                guessCount++;

                if (guess < magic)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magic)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {guessCount} guess{(guessCount == 1 ? "" : "es")}!");
                }
            }

            // Ask to play again
            Console.Write("\nPlay again? (yes/no): ");
            string? answer = Console.ReadLine();
            keepPlaying = answer != null && answer.Trim().Equals("yes", StringComparison.OrdinalIgnoreCase);

            if (keepPlaying)
            {
                Console.WriteLine("\n--- New Round ---");
            }
        }

        Console.WriteLine("Thanks for playing!");
    }
}
