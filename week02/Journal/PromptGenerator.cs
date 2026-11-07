using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>();
    private Random _random = new Random();

    public PromptGenerator()
    {
        // Core course prompts
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the hand of the Lord in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");

        // Custom additional prompts (to inspire reflective writing)
        _prompts.Add("What was an unexpected challenge I faced today, and how did I respond to it?");
        _prompts.Add("What is one new thing or insight I learned today that I want to remember?");
        _prompts.Add("Who made a positive difference in my day, and how can I express gratitude?");
        _prompts.Add("What is a small victory or accomplishment that brought me peace today?");
        _prompts.Add("What gave me hope or energy today when things got difficult?");
    }

    public string GetRandomPrompt()
    {
        if (_prompts.Count == 0)
        {
            return "What is on your mind today?";
        }

        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}
