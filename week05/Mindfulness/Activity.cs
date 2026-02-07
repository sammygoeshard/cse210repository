using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration; 

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public string GetName() => _name;
    public string GetDescription() => _description;
    public int GetDuration() => _duration;

 
    public void DisplayStartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine(_description);
        Console.Write("\nHow long, in seconds, would you like for your session? ");

        _duration = int.Parse(Console.ReadLine().Trim());

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public void DisplayEndMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);

        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(4);
    }

    // Spinner animation (requirements)
    public void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < end)
        {
            Console.Write(frames[i]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            i = (i + 1) % frames.Length;
        }
    }

   
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public DateTime GetEndTime()
    {
        return DateTime.Now.AddSeconds(_duration);
    }

}
