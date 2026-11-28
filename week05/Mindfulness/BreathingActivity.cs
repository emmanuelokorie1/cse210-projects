using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity",
               "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime futureTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < futureTime)
        {
            Console.Write("Breathe in... ");
            ShowPacedCountDown(4, true);
            Console.WriteLine();

            Console.Write("Now breathe out... ");
            ShowPacedCountDown(6, false);
            Console.WriteLine("\n");
        }

        DisplayEndingMessage();
    }

    // Exceeding Requirement: Paced visual breathing bar expanding and contracting with the count
    private void ShowPacedCountDown(int seconds, bool inhale)
    {
        for (int i = seconds; i > 0; i--)
        {
            int barUnits = inhale ? (seconds - i + 1) * 2 : i * 2;
            string bar = new string('=', barUnits);
            string prompt = $"{i} [{bar}>]";
            Console.Write(prompt);
            Thread.Sleep(1000);

            // Erase the prompt
            string eraser = new string('\b', prompt.Length) + new string(' ', prompt.Length) + new string('\b', prompt.Length);
            Console.Write(eraser);
        }
    }
}
