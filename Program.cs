using System;

class Program
{
    static void Main(string[] args)
    {
        // Ensure the correct number of arguments are provided
        if (args.Length < 2)
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("  hanoi -Recursive <number_of_disks>");
            Console.WriteLine("  hanoi -Iterative <number_of_disks>");
            return;
        }

        int n;
        // Validate if the second argument is a positive integer
        if (!int.TryParse(args[1], out n) || n < 1)
        {
            Console.WriteLine("Please enter a valid number of disks (positive integer).");
            return;
        }

        // Initialize the ASCII visualization of the towers
        HanoiVisualizer.InitializePegs(n);

        // Determine which method to use based on the first argument
        if (args[0] == "-Recursive")
        {
            Console.WriteLine($"Solving Tower of Hanoi Recursively for {n} disks:");
            RecursiveHanoi.Solve(n, 'L', 'R', 'M'); // Solve using recursion
        }
        else if (args[0] == "-Iterative")
        {
            Console.WriteLine($"Solving Tower of Hanoi Iteratively for {n} disks:");
            IterativeHanoi.Solve(n, 'L', 'R', 'M'); // Solve using iteration
        }
        else
        {
            // Invalid argument provided
            Console.WriteLine("Invalid option! Use -Recursive or -Iterative.");
        }
    }
}
