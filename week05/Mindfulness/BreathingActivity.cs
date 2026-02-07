using System;

public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description, int duration)
        : base(name, description, duration)
    { }

    public void Run()
    {
        DisplayStartMessage();

        DateTime endTime = GetEndTime();

        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in... ");
            ShowCountDown(4);

            if (DateTime.Now >= endTime) break;

            Console.Write("\nBreathe out... ");
            ShowCountDown(6);
        }

        Console.WriteLine();
        DisplayEndMessage();
    }
}
