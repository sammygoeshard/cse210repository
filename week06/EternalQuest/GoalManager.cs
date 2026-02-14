using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    private string _username = "user";

    // Motivational quotes
    private readonly List<string> _quotes = new List<string>
    {
        "Small steps every day add up to big results.",
        "You build who you want to be by doing what you want to do.",
        "Discipline beats motivation when motivation fades.",
        "The secret to getting ahead is getting started.",
        "You don’t have to be great to start, but you have to start to be great.",
        "Keep going — your future self will thank you.",
        "Consistency is a superpower.",
        "Focus on the next step, not the whole staircase."
    };

    private readonly Random _rand = new Random();

    public GoalManager(int startingScore = 0)
    {
        _score = startingScore;
    }


    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            Console.Clear();

            Console.WriteLine($"Welcome back {_username}");
            Console.WriteLine($"💡 {GetRandomQuote()}");
            DisplayPlayerInfo();

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Quit");
            Console.Write("Select a choice from the Menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoals(); Pause(); break;
                case "2": ListGoalsDetails(); Pause(); break;

                case "3":
                    Console.Write("Filename to save: ");
                    SaveGoals(Console.ReadLine());
                    Pause();
                    break;

                case "4":
                    Console.Write("Filename to load: ");
                    LoadGoals(Console.ReadLine());
                    Pause();
                    break;

                case "5": RecordEvent(); Pause(); break;
                case "6": Console.WriteLine("Goodbye!"); break;

                default:
                    Console.WriteLine("Invalid choice.");
                    Pause();
                    break;
            }
        }
    }

    private string GetRandomQuote()
    {
        if (_quotes.Count == 0) return "Keep pushing forward!";
        return _quotes[_rand.Next(_quotes.Count)];
    }

    public void DisplayPlayerInfo()
    {
        int level = (_score / 1000) + 1;
        Console.WriteLine($"You have {_score} points (Level {level})");
    }

    public void ListGoalsDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoals()
    {
        Console.WriteLine("\n1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create: ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal?: ");
        string name = Console.ReadLine();

        Console.Write("What is the short Description?: ");
        string desc = Console.ReadLine();

        int points = ReadInt("What is the amount of points associated with this goal?: ");

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, desc, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, desc, points));
        }
        else if (type == "3")
        {
            int target = ReadInt("How many times does this goal need to be accomplished for a bonus: ");
            int bonus = ReadInt("What is the bonus for accomplishing it that many times?: ");

            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
        else
        {
            Console.WriteLine("Invalid type.");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        Console.WriteLine("The goals are: ");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }

        int index = ReadInt("Select goal number: ") - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        int earned = _goals[index].RecordEvent();
        _score += earned;

        Console.WriteLine($"Horray!!! You earned {earned} points!");
        Console.WriteLine("✨ Keep pushing forward!");
    }

    public void SaveGoals(string filename)
    {
        
        if (_username == "user")
        {
            Console.Write("Enter your username");
            _username = Console.ReadLine();
        }
        using (StreamWriter writer = new StreamWriter(filename))
        {
            // Save username and score first
            writer.WriteLine(_username);
            writer.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        if (lines.Length < 2)
        {
            Console.WriteLine("File format invalid.");
            return;
        }

        _goals.Clear();


        _username = lines[0].Trim();
        _score = int.Parse(lines[1]);

        for (int i = 2; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');

            if (parts[0] == "Simple")
                _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));

            else if (parts[0] == "Eternal")
                _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));

            else if (parts[0] == "Checklist")
                _goals.Add(new ChecklistGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[5]),
                    int.Parse(parts[4]),
                    int.Parse(parts[6])));
        }

        Console.WriteLine($"Goals loaded. Welcome back, {_username}!");
    }

    private static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value))
                return value;

            Console.WriteLine("Enter a valid number.");
        }
    }

    private static void Pause()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}
