using System;

class RecursiveHanoi
{
    // Recursive function to solve Tower of Hanoi
    public static void Solve(int n, char from, char to, char aux)
    {
        // Base case: If there's only one disk, move it directly from 'from' to 'to'
        if (n == 1)
        {
            Console.WriteLine($"Move disk 1 from {from} to {to}");
            return; // End function for this case
        }

        // Step 1: Move (n-1) disks from 'from' to 'aux' using 'to' as an auxiliary peg
        Solve(n - 1, from, aux, to);

        // Step 2: Move the nth (largest) disk directly from 'from' to 'to'
        Console.WriteLine($"Move disk {n} from {from} to {to}");

        // Step 3: Move (n-1) disks from 'aux' to 'to' using 'from' as an auxiliary peg
        Solve(n - 1, aux, to, from);
    }
}
