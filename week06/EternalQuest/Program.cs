using System;

// =============================================================
// EXCEEDING REQUIREMENTS:
// 1) Added a simple Level system (every 1000 points = new level).
// 2) Added celebration message when earning points.
// 4) Random motivational quote after welcome
// =============================================================

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Eternal Quest Program!");
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
