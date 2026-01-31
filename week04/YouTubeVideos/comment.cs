public class Comment
{
    private string _name;
    private string _commentText;

    public Comment(string name, string text)
    {
        _name = name;
        _commentText = text;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetText()
    {
        return _commentText;
    }
}
