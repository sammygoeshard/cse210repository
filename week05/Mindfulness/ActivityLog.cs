using System;
using System.Collections.Generic;

public class ActivityLog
{
    private readonly Dictionary<string, int> _counts = new();

    public void Record(string activityName)
    {
        if (_counts.ContainsKey(activityName))
            _counts[activityName]++;
        else
            _counts[activityName] = 1;
    }

    public void Display()
    {
        Console.WriteLine("Activity Log (this session):\n");

        if (_counts.Count == 0)
        {
            Console.WriteLine("No activities performed yet.");
            return;
        }

        foreach (var kvp in _counts)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}
