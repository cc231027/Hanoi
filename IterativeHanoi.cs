using System;
using System.Collections.Generic;

class IterativeHanoi
{
    // Class to represent a move operation in the iterative approach
    class Move
    {
        public int Disk { get; set; } // The disk number to move
        public char From { get; set; } // The source peg
        public char To { get; set; } // The destination peg
    }

    // Iterative solution using a stack
    public static void Solve(int n, char from, char to, char aux)
    {
        // Create a stack to simulate the recursive function calls
        Stack<Move> stack = new Stack<Move>();

        // Push the first move operation onto the stack (Move n disks from 'from' to 'to')
        stack.Push(new Move { Disk = n, From = from, To = to });

        // Loop until all moves are completed
        while (stack.Count > 0)
        {
            // Pop the top move from the stack
            Move move = stack.Pop();
            int disk = move.Disk;
            char src = move.From;
            char dest = move.To;

            // Dynamically find the auxiliary peg (A + B + C - source - destination)
            char temp = (char)('A' + 'B' + 'C' - src - dest);

            // Base case: If it's a single disk, move it directly
            if (disk == 1)
            {
                Console.WriteLine($"Move disk {disk} from {src} to {dest}");
            }
            else
            {
                // Step 3: Move (n-1) disks from auxiliary peg to destination peg
                stack.Push(new Move { Disk = disk - 1, From = temp, To = dest });

                // Step 2: Move the nth (largest) disk from source peg to destination peg
                stack.Push(new Move { Disk = 1, From = src, To = dest });

                // Step 1: Move (n-1) disks from source peg to auxiliary peg
                stack.Push(new Move { Disk = disk - 1, From = src, To = temp });
            }
        }
    }
}
