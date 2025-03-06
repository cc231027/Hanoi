using System;

class Program
{
    static void Main(string[] args)
    {
        // Check if the correct number of arguments is provided
        if (args.Length < 2)
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("  hanoi -Recursive <number_of_disks>");
            Console.WriteLine("  hanoi -Iterative <number_of_disks>");
            return; // Exit program if arguments are incorrect
        }

        int n;
        // Try parsing the second argument to an integer (number of disks)
        if (!int.TryParse(args[1], out n) || n < 1)
        {
            Console.WriteLine("Please enter a valid number of disks (positive integer).");
            return; // Exit program if input is invalid
        }

        // Check if the user wants to use the recursive approach
        if (args[0] == "-Recursive")
        {
            Console.WriteLine($"Solving Tower of Hanoi Recursively for {n} disks:");
            // Call the recursive Tower of Hanoi solution
            RecursiveHanoi.Solve(n, 'L', 'R', 'M'); // L = Left, R = Right, M = Middle
        }
        // Check if the user wants to use the iterative approach
        else if (args[0] == "-Iterative")
        {
            Console.WriteLine($"Solving Tower of Hanoi Iteratively for {n} disks:");
            // Call the iterative Tower of Hanoi solution
            IterativeHanoi.Solve(n, 'L', 'R', 'M');
        }
        // If the user entered an invalid option, display an error message
        else
        {
            Console.WriteLine("Invalid option! Use -Recursive or -Iterative.");
        }
    }
}
