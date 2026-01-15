
using System;
using System.Collections.Generic;

public class Resume
{
    // Person's name
    public string _name;

    // List of Job objects
    public List<Job> _jobs = new List<Job>();

    // Displays the person's name, then each job
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}
