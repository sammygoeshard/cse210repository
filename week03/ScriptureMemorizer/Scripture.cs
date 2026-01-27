public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
// Constructor Logic from the quiz
    public Scripture(Reference Reference, string text)
    {
        _reference = Reference;
    // Split the text into words and create Word objects
        string[] wordsArray = text.Split(' ');
        foreach (string wordText in wordsArray)
        {
            Word word = new Word(wordText);
            _words.Add(word);
        }            
    }

 

public void HideRandomWords(int numberToHide)
{
    Random random = new Random();
    
    // 1. Create a list of indexes that are NOT hidden yet
    List<int> availableIndexes = new List<int>();
    for (int i = 0; i < _words.Count; i++)
    {
        if (!_words[i].IsHidden())
        {
            availableIndexes.Add(i);
        }
    }

    // 2. Hide words based on the numberToHide
    // We use Math.Min to make sure we don't try to hide more words than are left
    int actuallyHide = Math.Min(numberToHide, availableIndexes.Count);

    for (int i = 0; i < actuallyHide; i++)
    {
        // Pick a random index from our 'available' list
        int randomIndexInAvailable = random.Next(availableIndexes.Count);
        int wordIndexToHide = availableIndexes[randomIndexInAvailable];

        _words[wordIndexToHide].Hide();

        // Remove it from available list so we don't pick it again in this same turn
        availableIndexes.RemoveAt(randomIndexInAvailable);
    }
}

    public string GetDisplayText()
    {
        string scriptureText = "";
    foreach (Word word in _words)
    {
        scriptureText += word.GetDisplayText() + " ";
    }
    return $"{_reference.GetDisplayText()} {scriptureText.Trim()}";
    }

    public bool IsCompletelyHidden ()
    {
    // If ANY word is NOT hidden, return false
        foreach (var word in _words)
        {
            if (!word.IsHidden()) return false;
        }
        return true; // All words are hidden
    }
}
    
