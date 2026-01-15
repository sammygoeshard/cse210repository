
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        var numbers = new List<double>();

        while (true)
        {
            Console.Write("Enter number: ");
            string? input = Console.ReadLine();

            if (!double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
            {
                Console.WriteLine("Invalid number. Please try again.");
                continue;
            }

            if (value == 0)
            {
                // Stop and DO NOT add 0 to the list
                break;
            }

            numbers.Add(value);
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("\nNo numbers were entered. Nothing to compute.");
            return;
        }

        // --- Core requirements ---
        double sum = numbers.Sum();
        double average = sum / numbers.Count;
        double largest = numbers.Max();

        Console.WriteLine($"\nThe sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");

        // --- Stretch #1: Smallest positive number (closest to zero) ---
        var positives = numbers.Where(n => n > 0);
        if (positives.Any())
        {
            double smallestPositive = positives.Min();
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("There are no positive numbers in the list.");
        }

        // --- Stretch #2: Sort numbers and display ---
        var sorted = numbers.OrderBy(n => n).ToList();

        Console.WriteLine("The sorted list is:");
        foreach (double n in sorted)
        {
            Console.WriteLine(n);
        }
    }
}


