using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.Write("Enter your grade percentage (e.g., 86 or 86.5): ");

        string input = Console.ReadLine() ?? string.Empty;
        if (!double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double percent))
        {
            Console.WriteLine("Invalid number. Please run again and enter a numeric grade percentage.");
            return;
        }

        // STEP 1: Determine the base letter
        string letter;
        if (percent >= 90)
            letter = "A";
        else if (percent >= 80)
            letter = "B";
        else if (percent >= 70)
            letter = "C";
        else if (percent >= 60)
            letter = "D";
        else
            letter = "F";

        // STEP 2: Determine sign (+, -, or none)
        string sign = string.Empty;

        // Only assign signs for A, B, C, D
        if (letter != "F")
        {
            // Work with the integer portion for last-digit rule
            int whole = (int)Math.Floor(percent);
            int lastDigit = Math.Abs(whole) % 10;

            if (lastDigit >= 7)
                sign = "+";
            else if (lastDigit < 3)
                sign = "-";
            else
                sign = string.Empty;

            // EXCEPTION: No A+
            if (letter == "A" && sign == "+")
            {
                sign = string.Empty; // Remove plus for A+
            }
        }
        else
        {
            // EXCEPTION: No F+ or F-
            sign = string.Empty;
        }

        // Final formatted grade
        string formatted = letter + sign;

        Console.WriteLine($"\nLetter grade: {formatted}");

        // Pass/Fail message (passing is 70+)
        if (percent >= 70)
            Console.WriteLine("Congratulations! You passed the course.");
        else
            Console.WriteLine("Keep going—you can do this! Study a bit more and try again next time.");
    }
}