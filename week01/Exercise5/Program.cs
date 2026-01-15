
using System;

class Program
{
    static void Main()
    {
        DisplayWelcome();

       
        string name = PromptUserName();

       
        int favoriteNumber = PromptUserNumber();

       
        int squared = SquareNumber(favoriteNumber);

        
        DisplayResult(name, squared);
    }

    /// <summary>
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    /// <summary>
    /// Asks for and returns the user's name.
    /// 
    /// <returns>User's name as a string.</returns>
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string? name = Console.ReadLine();
        // Handle null/empty gracefully
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.Write("Name cannot be empty. Please enter your name: ");
            name = Console.ReadLine();
        }
        return name.Trim();
    }

    /// <summary>
    /// Asks for and returns the user's favorite number as an integer.
    /// Includes simple validation.
    /// </summary>
    /// <returns>Favorite number as an int.</returns>
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string? input = Console.ReadLine();
        int number;

        // Keep prompting until a valid integer is entered
        while (!int.TryParse(input, out number))
        {
            Console.Write("That's not a valid whole number. Try again: ");
            input = Console.ReadLine();
        }

        return number;
    }

    /// <summary>
    /// Returns the square of the given integer.
    /// </summary>
    /// <param name="number">The number to square.</param>
    /// <returns>Squared value (number * number).</returns>
    static int SquareNumber(int number)
    {
        // Using checked to throw if the square overflows int (optional)
        checked
        {
            return number * number;
        }
    }

    /// <summary>
    /// Displays the final message with the user's name and the squared value.
    /// </summary>
    /// <param name="name">User's name</param>
    /// <param name="squaredNumber">Squared favorite number</param>
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}
