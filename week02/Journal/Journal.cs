using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    // Add a new entry to the journal
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Display all entries in the journal
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\n[Your journal is currently empty. Write a new entry to get started!]\n");
            return;
        }

        Console.WriteLine("\n=================== Journal Entries ===================");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
        Console.WriteLine("=======================================================\n");
    }

    // Save entries to a file
    public void SaveToFile(string file)
    {
        // Check if the user specified a .csv file extension
        if (file.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
        {
            SaveToCsv(file);
            return;
        }

        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                // Delimiter: ~|~ avoids accidental collisions with commas, pipes, or quotes
                outputFile.WriteLine($"{entry._date}~|~{entry._promptText}~|~{entry._entryText}~|~{entry._mood}");
            }
        }

        Console.WriteLine($"\nSuccessfully saved {_entries.Count} entries to '{file}'.\n");
    }

    // Load entries from a file (replaces current entries)
    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine($"\n[Error] The file '{file}' does not exist. Please check the filename and path.\n");
            return;
        }

        string[] lines = File.ReadAllLines(file);
        _entries.Clear(); // Replacing any entries currently in the journal per specification

        // Check if loading from CSV
        if (file.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
        {
            LoadFromCsv(lines);
            Console.WriteLine($"\nSuccessfully loaded {_entries.Count} entries from '{file}'.\n");
            return;
        }

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] parts = line.Split("~|~");
            if (parts.Length >= 3)
            {
                Entry entry = new Entry();
                entry._date = parts[0];
                entry._promptText = parts[1];
                entry._entryText = parts[2];
                entry._mood = parts.Length >= 4 ? parts[3] : "Not Specified";

                _entries.Add(entry);
            }
        }

        Console.WriteLine($"\nSuccessfully loaded {_entries.Count} entries from '{file}'.\n");
    }

    // Exceeding Requirement: Save to formatted CSV with RFC-4180 escaping (opens directly in Excel)
    private void SaveToCsv(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            // CSV Header
            outputFile.WriteLine("Date,Prompt,Response,Mood");
            foreach (Entry entry in _entries)
            {
                string safeDate = EscapeCsvField(entry._date);
                string safePrompt = EscapeCsvField(entry._promptText);
                string safeResponse = EscapeCsvField(entry._entryText);
                string safeMood = EscapeCsvField(entry._mood);

                outputFile.WriteLine($"{safeDate},{safePrompt},{safeResponse},{safeMood}");
            }
        }

        Console.WriteLine($"\nSuccessfully exported {_entries.Count} entries to CSV format: '{file}'.\n");
    }

    // Exceeding Requirement: Load from CSV handling standard comma separation
    private void LoadFromCsv(string[] lines)
    {
        // Skip header line if present
        int startIndex = (lines.Length > 0 && lines[0].StartsWith("Date,", StringComparison.OrdinalIgnoreCase)) ? 1 : 0;

        for (int i = startIndex; i < lines.Length; i++)
        {
            string line = lines[i];
            if (string.IsNullOrWhiteSpace(line)) continue;

            List<string> fields = ParseCsvLine(line);
            if (fields.Count >= 3)
            {
                Entry entry = new Entry();
                entry._date = fields[0];
                entry._promptText = fields[1];
                entry._entryText = fields[2];
                entry._mood = fields.Count >= 4 ? fields[3] : "Not Specified";
                _entries.Add(entry);
            }
        }
    }

    // Helper to escape CSV fields according to RFC 4180
    private string EscapeCsvField(string field)
    {
        if (field == null) return "\"\"";
        if (field.Contains(",") || field.Contains("\"") || field.Contains("\n") || field.Contains("\r"))
        {
            return $"\"{field.Replace("\"", "\"\"")}\"";
        }
        return field;
    }

    // Helper to parse a CSV line accounting for quotes
    private List<string> ParseCsvLine(string line)
    {
        List<string> result = new List<string>();
        bool inQuotes = false;
        string current = "";

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (c == '\"')
            {
                if (inQuotes && i + 1 < line.Length && line[i + 1] == '\"')
                {
                    current += '\"';
                    i++;
                }
                else
                {
                    inQuotes = !inQuotes;
                }
            }
            else if (c == ',' && !inQuotes)
            {
                result.Add(current);
                current = "";
            }
            else
            {
                current += c;
            }
        }
        result.Add(current);
        return result;
    }
}
