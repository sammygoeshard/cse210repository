
public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _mood;

    public string _energyLevel;

    public Entry()
    {
        _date = DateTime.Now.ToShortDateString();
    }

    public void Display()
    {
        Console.WriteLine($"{_date}: {_promptText}");
        Console.WriteLine($"******{_entryText}");
        Console.WriteLine($"*****Mood: {_mood}     Energy Level: {_energyLevel}");
        Console.WriteLine();
    }
}
