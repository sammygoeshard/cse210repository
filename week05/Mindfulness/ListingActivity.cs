using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private readonly ShuffleBag<string> _promptBag;

    public ListingActivity(string name, string description, int duration, int count)
        : base(name, description, duration)
    {
        _count = count;

        _promptBag = new ShuffleBag<string>(new List<string>
        {
            "What are some small things that made you smile today?",
            "Which parts of your home or environment are you most grateful for?",
            "What are some skills or talents you possess that you appreciate?",
            "Think of specific experiences from the last year that brought you joy."
        });
    }

    public void Run()
    {
        DisplayStartMessage();

        string prompt = _promptBag.Next();
        Console.WriteLine("List responses to the following prompt:\n");
        Console.WriteLine($"--- {prompt} ---");

        Console.Write("\nYou may begin in: ");
        ShowCountDown(5);

        Console.WriteLine("\nEnter items (press Enter after each one):");

        DateTime endTime = GetEndTime();
        _count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();

            if (DateTime.Now >= endTime) break;

            if (!string.IsNullOrWhiteSpace(item))
                _count++;
        }

        Console.WriteLine($"\nYou listed {_count} items!");

        DisplayEndMessage();
    }
}
