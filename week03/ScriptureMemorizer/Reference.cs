public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _startVerse;
    private int _endVerse;

    // Constructor for a single verse (John 3:16)
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = 0; // Ensures the logic in GetDisplayText knows it's a single verse
    }

    // Constructor for a range of verses (e.g., Proverbs 3:5-6)
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse; // Use startVerse here
        _verse = startVerse;      // Setting _verse to startVerse keeps things compatible
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_endVerse == 0)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }
}