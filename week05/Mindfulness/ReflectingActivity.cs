using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private readonly ShuffleBag<string> _promptBag;
    private readonly ShuffleBag<string> _questionBag;

    public ReflectingActivity(string name, string description, int duration)
        : base(name, description, duration)
    {
        _promptBag = new ShuffleBag<string>(new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        });

        _questionBag = new ShuffleBag<string>(new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        });
    }

    public void Run()
    {
        DisplayStartMessage();

        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($"--- {_promptBag.Next()} ---");

        Console.Write("\nWhen you have something in mind, press Enter to continue... ");
        Console.ReadLine();

        Console.WriteLine("\nNow ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        DateTime endTime = GetEndTime();

        while (DateTime.Now < endTime)
        {
            Console.Write($"\n> {_questionBag.Next()} ");
            ShowSpinner(6);
        }

        Console.WriteLine();
        DisplayEndMessage();
    }
}
