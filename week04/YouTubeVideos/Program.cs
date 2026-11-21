using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("          YOUTUBE VIDEO TRACKING SYSTEM           ");
        Console.WriteLine("==================================================\n");

        // ------------------------------------------------------------------
        // Video 1: C# Object-Oriented Programming Tutorial
        // ------------------------------------------------------------------
        Video video1 = new Video("C# Object-Oriented Programming in 20 Minutes", "Tech With Tim", 1250);
        video1.AddComment(new Comment("Alex Chen", "The explanation of encapsulation was crystal clear!"));
        video1.AddComment(new Comment("Maria Garcia", "Finally understood the difference between classes and objects."));
        video1.AddComment(new Comment("David Kim", "Saved this to my favorites. Great pace and code examples."));
        video1.AddComment(new Comment("Sarah Connor", "Looking forward to your next video on inheritance and polymorphism."));

        // ------------------------------------------------------------------
        // Video 2: Full-Stack Web Development Roadmap
        // ------------------------------------------------------------------
        Video video2 = new Video("Full-Stack Web Development Complete Roadmap 2026", "Traversy Media", 1820);
        video2.AddComment(new Comment("James Wilson", "Incredible breakdown of modern web tech stacks."));
        video2.AddComment(new Comment("Elena Rostova", "I appreciate you emphasizing fundamentals before frameworks."));
        video2.AddComment(new Comment("Kwame Mensah", "Watching this right as I start my software engineering degree!"));

        // ------------------------------------------------------------------
        // Video 3: Top 10 Mechanical Keyboards Review
        // ------------------------------------------------------------------
        Video video3 = new Video("Top 10 Mechanical Keyboards for Coders & Writers", "Hardware Canucks", 945);
        video3.AddComment(new Comment("Chloe Bennet", "The sound test on switch #4 was unbelievable."));
        video3.AddComment(new Comment("Marcus Aurelius", "Typing comfort matters so much when you code all day."));
        video3.AddComment(new Comment("Liam O'Connor", "Ordered the second keyboard featured in the clip! Excellent review."));
        video3.AddComment(new Comment("Priya Sharma", "Can you do an update comparing wireless latency?"));

        // ------------------------------------------------------------------
        // Video 4: Data Structures & Algorithms Visualized
        // ------------------------------------------------------------------
        Video video4 = new Video("Binary Trees & Graph Traversals Visualized", "Computerphile", 1480);
        video4.AddComment(new Comment("Zack Snyder", "The animated diagrams made DFS and BFS so intuitive."));
        video4.AddComment(new Comment("Nadia Petrova", "Best university exam prep video on the internet."));
        video4.AddComment(new Comment("Carlos Mendez", "Subscribed! Keep making high quality CS theory content."));

        // Store all videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Iterate through each video and display its full summary
        for (int i = 0; i < videos.Count; i++)
        {
            Console.WriteLine($"******************* VIDEO #{i + 1} *******************");
            videos[i].Display();
            Console.WriteLine("***************************************************\n");
        }
    }
}
