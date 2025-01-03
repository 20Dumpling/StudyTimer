using System;
using System.Threading;
class Program
{
    static void Main()
    {
        // Welcome Message
        Console.WriteLine("Welcome to lain's very own study timer");
        Console.WriteLine("Study hard, break light, it's the 40-25 rule, gambare!");
        Console.WriteLine("Press 'Enter' to start.");
        Console.ReadLine();

        bool isRunning = true;

        while (isRunning)
        {
            // Start the Study Timer
            Console.WriteLine("Study time lain!");
            RunTimer(40);
            Console.WriteLine("Study overrrrrr");

            // Start the Break Timer
            Console.WriteLine("Break time weeeeeee");
            RunTimer(25);
            Console.WriteLine("Stay hard, back to studying!");

            // Pause or Continue Option
            Console.WriteLine("Press 'P' to pause, or 'Enter' to continue.");
            var input = Console.ReadKey(intercept: true); // Read input without displaying
            if (input.Key == ConsoleKey.P)
            {
                Console.WriteLine("\nPaused. Press 'Enter' to resume or 'E' to exit.");
                input = Console.ReadKey(intercept: true);
                if (input.Key == ConsoleKey.E)
                {
                    Console.WriteLine("\nExiting the timer. Goodbye!");
                    isRunning = false; // Stop the loop
                }
            }
        }
    }

    // Method to Run the Timer
    static void RunTimer(int minutes)
    {
        int totalSeconds = minutes * 60;
        bool isPaused = false; // Flag to control pausing

        for (int i = totalSeconds; i > 0; i--)
        {
            // Clear the console and display the timer
            Console.Clear();
            Console.WriteLine($"Time remaining: {i / 60:D2}:{i % 60:D2}");

            // Check for key press in smaller intervals
            int delay = 100; // Check every 100 milliseconds
            int steps = 1000 / delay;

            for (int j = 0; j < steps; j++)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true); // Read input without displaying
                    if (key.Key == ConsoleKey.P)
                    {
                        isPaused = true; // Pause the timer
                        Console.WriteLine("\nTimer paused. Press 'Enter' to resume or 'E' to exit.");
                        while (isPaused)
                        {
                            var pauseKey = Console.ReadKey(intercept: true);
                            if (pauseKey.Key == ConsoleKey.Enter)
                            {
                                Console.WriteLine("\nResuming the timer...");
                                isPaused = false; // Resume the timer
                            }
                            else if (pauseKey.Key == ConsoleKey.E)
                            {
                                Console.WriteLine("\nExiting the timer. Goodbye!");
                                Environment.Exit(0); // Exit the program
                            }
                        }
                    }
                }

                if (!isPaused)
                {
                    Thread.Sleep(delay); // Continue the timer if not paused
                }
            }
        }
    }
}
