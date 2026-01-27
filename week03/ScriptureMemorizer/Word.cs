public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false; // By default, words start visible
    }

        public bool IsHidden()
    {
        return _isHidden;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public string GetDisplayText()
    {
        // If hidden, return underscores matching the length of the original text
        if (_isHidden)
        {
            // This creates a new string of underscores equal to the text length
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}