/*
 * CSE 210: Programming with Classes
 * Week 05 Project: Mindfulness Program
 * Student: Emmanuel Okorie
 * 
 * Exceeding Requirements & Creativity:
 * 1. Activity Session Logger & Statistics Tracker:
 *    - Keeps track of session history throughout program execution, recording the number of times
 *      each activity was performed and the total time spent across all sessions.
 *    - Option 4 in the menu displays a session summary dashboard showing counts and cumulative duration.
 *
 * 2. Non-Repeating Random Questions & Prompts:
 *    - Both ReflectingActivity and ListingActivity implement a smart shuffling queue (_unusedPrompts and _unusedQuestions).
 *    - Prompts and questions are never repeated in a session until all available items have been presented at least once.
 *
 * 3. Dynamic Visual Breath Bar Animation:
 *    - In BreathingActivity, an expanding and contracting progress visual (e.g. "[==>]", "[====>]")
 *      synchronizes with the countdown seconds for an intuitive, paced visual breathing guide.
 *
 * 4. Input Validation:
 *    - Guarded duration inputs ensure only valid positive integers are accepted without throwing exceptions.
 */

using System;
using System.Collections.Generic;

class Program
{
    private static int _breathingCount = 0;
    private static int _reflectingCount = 0;
    private static int _listingCount = 0;
    private static int _totalSecondsSpent = 0;

    static void Main(string[] args)
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View session log & statistics");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    _breathingCount++;
                    _totalSecondsSpent += breathing.GetDuration();
                    break;

                case "2":
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    _reflectingCount++;
                    _totalSecondsSpent += reflecting.GetDuration();
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    _listingCount++;
                    _totalSecondsSpent += listing.GetDuration();
                    break;

                case "4":
                    DisplaySessionLog();
                    break;

                case "5":
                    Console.WriteLine("\nThank you for taking time for mindfulness today. Have a peaceful day!\n");
                    keepRunning = false;
                    break;

                default:
                    Console.WriteLine("\nInvalid option. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private static void DisplaySessionLog()
    {
        Console.Clear();
        Console.WriteLine("==================================================");
        Console.WriteLine("          MINDFULNESS SESSION LOG & STATS         ");
        Console.WriteLine("==================================================");
        Console.WriteLine($"Breathing Activities Completed:   {_breathingCount}");
        Console.WriteLine($"Reflecting Activities Completed:  {_reflectingCount}");
        Console.WriteLine($"Listing Activities Completed:     {_listingCount}");
        Console.WriteLine($"Total Completed Sessions:         {_breathingCount + _reflectingCount + _listingCount}");
        Console.WriteLine($"Total Mindfulness Time:           {_totalSecondsSpent} seconds ({_totalSecondsSpent / 60}m {_totalSecondsSpent % 60}s)");
        Console.WriteLine("==================================================");
        Console.WriteLine("\nPress Enter to return to the main menu...");
        Console.ReadLine();
    }
}
