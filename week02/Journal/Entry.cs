using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _mood; // Exceeding requirement: emotional state tracking

    // Default constructor
    public Entry()
    {
    }

    // Parameterized constructor
    public Entry(string date, string promptText, string entryText, string mood = "Neutral")
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText} [Mood: {_mood}]");
        Console.WriteLine($"> {_entryText}");
        Console.WriteLine();
    }
}
