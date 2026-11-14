/*
 * CSE 210: Programming with Classes
 * Week 03 Project: Scripture Memorizer Program
 * Student: Emmanuel Okorie
 * 
 * Exceeding Requirements & Creativity:
 * 1. Only Pick From Unhidden Words (Stretch Challenge):
 *    - The Scripture.HideRandomWords() method specifically filters for words where
 *      !word.IsHidden() before making random selections. This ensures that every press
 *      of the Enter key always hides new words and avoids wasting selections on words
 *      that are already hidden.
 *
 * 2. Punctuation Preservation:
 *    - In Word.GetDisplayText(), alphanumeric characters are converted to underscores
 *      matching their exact length, but commas, semicolons, quotes, and periods are
 *      preserved (e.g., "______,"). This maintains grammatical rhythm and structural
 *      clues that assist the user in memorization.
 *
 * 3. Scripture Library Support:
 *    - The program includes a built-in library of diverse scriptures (both single verses
 *      and multi-verse passages) including Proverbs 3:5-6, John 3:16, Philippians 4:13,
 *      and D&C 6:36. Users can either let the program pick a random passage or select
 *      their preferred passage to memorize.
 */

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> library = InitializeScriptureLibrary();

        Console.Clear();
        Console.WriteLine("==================================================");
        Console.WriteLine("     Welcome to the Scripture Memorizer Program!  ");
        Console.WriteLine("==================================================");
        Console.WriteLine("Choose a scripture to memorize:");
        Console.WriteLine("1. Proverbs 3:5-6 (Multi-verse)");
        Console.WriteLine("2. John 3:16 (Single verse)");
        Console.WriteLine("3. Philippians 4:13 (Single verse)");
        Console.WriteLine("4. Doctrine and Covenants 6:36 (Single verse)");
        Console.WriteLine("5. Random scripture from the library");
        Console.Write("\nEnter your choice (1-5, or press Enter for default Proverbs 3:5-6): ");

        string choice = Console.ReadLine()?.Trim();
        Scripture selectedScripture;

        switch (choice)
        {
            case "2":
                selectedScripture = library[1];
                break;
            case "3":
                selectedScripture = library[2];
                break;
            case "4":
                selectedScripture = library[3];
                break;
            case "5":
                Random random = new Random();
                selectedScripture = library[random.Next(library.Count)];
                break;
            default:
                selectedScripture = library[0];
                break;
        }

        // Main memorization loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");

            string input = Console.ReadLine();

            if (input != null && input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\nKeep up the great memorization work! Goodbye.\n");
                break;
            }

            // Hide 3 random unhidden words per turn
            selectedScripture.HideRandomWords(3);

            // If all words are now hidden, display the final hidden scripture once and terminate
            if (selectedScripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(selectedScripture.GetDisplayText());
                Console.WriteLine();
                Console.WriteLine("Great job! All words in the scripture are now hidden and memorized!");
                Console.WriteLine("Program ended.\n");
                break;
            }
        }
    }

    private static List<Scripture> InitializeScriptureLibrary()
    {
        List<Scripture> scriptures = new List<Scripture>();

        // 1. Proverbs 3:5-6 (Multi-verse range)
        Reference refProverbs = new Reference("Proverbs", 3, 5, 6);
        string textProverbs = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        scriptures.Add(new Scripture(refProverbs, textProverbs));

        // 2. John 3:16 (Single verse)
        Reference refJohn = new Reference("John", 3, 16);
        string textJohn = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        scriptures.Add(new Scripture(refJohn, textJohn));

        // 3. Philippians 4:13 (Single verse)
        Reference refPhil = new Reference("Philippians", 4, 13);
        string textPhil = "I can do all things through Christ which strengtheneth me.";
        scriptures.Add(new Scripture(refPhil, textPhil));

        // 4. Doctrine and Covenants 6:36 (Single verse)
        Reference refDc = new Reference("D&C", 6, 36);
        string textDc = "Look unto me in every thought; doubt not, fear not.";
        scriptures.Add(new Scripture(refDc, textDc));

        return scriptures;
    }
}
