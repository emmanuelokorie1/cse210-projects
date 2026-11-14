using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        // Split text into individual words while preserving whitespace structure
        string[] parts = text.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        // Stretch / Exceeding Requirement: Filter to select only from words that are not yet hidden
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        if (visibleWords.Count == 0)
        {
            return;
        }

        // Determine how many words to hide (do not exceed available visible words)
        int wordsToHideCount = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < wordsToHideCount; i++)
        {
            int randomIndex = _random.Next(visibleWords.Count);
            visibleWords[randomIndex].Hide();
            visibleWords.RemoveAt(randomIndex); // Avoid picking the same word again in this turn
        }
    }

    public string GetDisplayText()
    {
        List<string> displayedWords = new List<string>();
        foreach (Word word in _words)
        {
            displayedWords.Add(word.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()} {string.Join(" ", displayedWords)}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
