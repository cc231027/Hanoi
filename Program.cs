using System;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("  hanoi -Recursive <number_of_disks>");
            Console.WriteLine("  hanoi -Iterative <number_of_disks>");
            return;
        }

        int n;
        if (!int.TryParse(args[1], out n) || n < 1)
        {
            Console.WriteLine("Please enter a valid number of disks (positive integer).");
            return;
        }

        HanoiVisualizer.InitializePegs(n); // Initialize visual representation

        if (args[0] == "-Recursive")
        {
            Console.WriteLine($"Solving Tower of Hanoi Recursively for {n} disks:");
            RecursiveHanoi.Solve(n, 'L', 'R', 'M');
        }
        else if (args[0] == "-Iterative")
        {
            Console.WriteLine($"Solving Tower of Hanoi Iteratively for {n} disks:");
            IterativeHanoi.Solve(n, 'L', 'R', 'M');
        }
        else
        {
            Console.WriteLine("Invalid option! Use -Recursive or -Iterative.");
        }
    }
}
