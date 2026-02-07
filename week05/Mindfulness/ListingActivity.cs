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
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
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
