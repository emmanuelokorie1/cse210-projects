using System;
using System.Text;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        // When hidden, replace alphanumeric characters with underscores while preserving punctuation
        StringBuilder hiddenText = new StringBuilder();
        foreach (char c in _text)
        {
            if (char.IsLetterOrDigit(c))
            {
                hiddenText.Append('_');
            }
            else
            {
                hiddenText.Append(c);
            }
        }

        return hiddenText.ToString();
    }
}
