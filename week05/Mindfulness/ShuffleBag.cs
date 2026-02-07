using System;
using System.Collections.Generic;


//ADDITIONAL CREATIVTY
public class ShuffleBag<T>
{
    private readonly Random _rng = new Random();
    private readonly List<T> _original;
    private List<T> _bag;

    public ShuffleBag(IEnumerable<T> items)
    {
        _original = new List<T>(items);
        _bag = new List<T>();
        RefillAndShuffle();
    }

    public T Next()
    {
        if (_bag.Count == 0)
            RefillAndShuffle();

        T item = _bag[_bag.Count - 1];
        _bag.RemoveAt(_bag.Count - 1);
        return item;
    }

    private void RefillAndShuffle()
    {
        _bag = new List<T>(_original);

        for (int i = _bag.Count - 1; i > 0; i--)
        {
            int j = _rng.Next(i + 1);
            (_bag[i], _bag[j]) = (_bag[j], _bag[i]);
        }
    }
}
