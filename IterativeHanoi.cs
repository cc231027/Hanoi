using System;
using System.Collections.Generic;

class IterativeHanoi
{
    // Class to represent a move operation
    class Move
    {
        public int Disk { get; set; } // Disk number being moved
        public char From { get; set; } // Source peg
        public char To { get; set; } // Destination peg
    }

    // Iterative solution to the Tower of Hanoi problem
    public static void Solve(int n, char from, char to, char aux)
    {
        // Stack to store moves, simulating recursion
        Stack<Move> stack = new Stack<Move>();

        // Push initial move (move all disks from 'from' peg to 'to' peg)
        stack.Push(new Move { Disk = n, From = from, To = to });

        // Process stack until all moves are executed
        while (stack.Count > 0)
        {
            // Get the next move from the stack
            Move move = stack.Pop();
            int disk = move.Disk;
            char src = move.From;
            char dest = move.To;

            // Determine the auxiliary peg dynamically
            char temp = (src == 'L' && dest == 'R') || (src == 'R' && dest == 'L') ? 'M' :
                        (src == 'L' && dest == 'M') || (src == 'M' && dest == 'L') ? 'R' :
                        'L'; // Assign correct auxiliary peg

            // Base case: If it's a single disk, move it directly
            if (disk == 1)
            {
                HanoiVisualizer.MoveDisk(disk, src, dest);
            }
            else
            {
                // Step 3: Move (n-1) disks from auxiliary peg to destination peg
                stack.Push(new Move { Disk = disk - 1, From = temp, To = dest });

                // Step 2: Move the largest disk from source peg to destination peg
                stack.Push(new Move { Disk = 1, From = src, To = dest });

                // Step 1: Move (n-1) disks from source peg to auxiliary peg
                stack.Push(new Move { Disk = disk - 1, From = src, To = temp });
            }
        }
    }
}
