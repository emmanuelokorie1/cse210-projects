/*
 * CSE 210: Programming with Classes
 * Week 02 Project: Journal Program
 * Student: Emmanuel Okorie
 * 
 * Exceeding Requirements & Creativity:
 * 1. Emotional State / Mood Tracking:
 *    - To address the psychological barrier of feeling overwhelmed or having nothing to say,
 *      each entry tracks the user's current mood/emotion (e.g., Grateful, Joyful, Tired, Reflective).
 *    - Mood is displayed on review and persisted across save/load operations.
 *
 * 2. Robust File Validation:
 *    - The program validates file existence using File.Exists() before attempting to load,
 *      displaying a clean error message and preventing application crashes on missing or mistyped files.
 *
 * 3. Excel-Compatible CSV Export / Import:
 *    - In addition to standard delimited files (~|~), if the user provides a filename ending in ".csv",
 *      the program formats and exports valid RFC-4180 CSV with quotes properly escaped so the journal
 *      can be directly opened, analyzed, or graphed in Microsoft Excel or Google Sheets.
 *
 * 4. Expanded Prompt Library:
 *    - Provided 10 reflective, positive psychology-focused prompts (instead of the required 5)
 *      to encourage deeper personal reflections and prevent repetitiveness.
 */

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine("========================================");
        Console.WriteLine("   Welcome to the Journal Program!      ");
        Console.WriteLine("========================================");

        bool running = true;
        while (running)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    // Write a new entry
                    string randomPrompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {randomPrompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    Console.Write("How are you feeling right now? (e.g., Grateful, Motivated, Peaceful, Tired): ");
                    string mood = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(mood))
                    {
                        mood = "Neutral";
                    }

                    string currentDate = DateTime.Now.ToShortDateString();
                    Entry newEntry = new Entry(currentDate, randomPrompt, response, mood);
                    journal.AddEntry(newEntry);
                    Console.WriteLine("Entry recorded successfully!\n");
                    break;

                case "2":
                    // Display the journal
                    journal.DisplayAll();
                    break;

                case "3":
                    // Load the journal from a file
                    Console.Write("\nWhat is the filename you would like to load? ");
                    string loadFilename = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrWhiteSpace(loadFilename))
                    {
                        journal.LoadFromFile(loadFilename);
                    }
                    else
                    {
                        Console.WriteLine("Filename cannot be empty.\n");
                    }
                    break;

                case "4":
                    // Save the journal to a file
                    Console.Write("\nWhat is the filename you would like to save to? (Tip: use .csv to export for Excel): ");
                    string saveFilename = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrWhiteSpace(saveFilename))
                    {
                        journal.SaveToFile(saveFilename);
                    }
                    else
                    {
                        Console.WriteLine("Filename cannot be empty.\n");
                    }
                    break;

                case "5":
                    // Quit
                    Console.WriteLine("\nThank you for taking time to reflect and journal today. Goodbye!\n");
                    running = false;
                    break;

                default:
                    Console.WriteLine("\nInvalid option. Please enter a number between 1 and 5.\n");
                    break;
            }
        }
    }
}
