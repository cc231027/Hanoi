using System;
using System.Collections.Generic;
using System.Threading;

class HanoiVisualizer
{
    private static Dictionary<char, Stack<int>> pegs = new Dictionary<char, Stack<int>>();

    // Initializes the pegs with disks
    public static void InitializePegs(int n)
    {
        pegs.Clear();
        pegs['L'] = new Stack<int>();
        pegs['M'] = new Stack<int>();
        pegs['R'] = new Stack<int>();

        for (int i = n; i >= 1; i--)
        {
            pegs['L'].Push(i); // Add disks to the Left peg
        }

        DrawPegs(n);
    }

    // Draws the pegs and disks in ASCII format
    public static void DrawPegs(int n)
    {
    Console.Clear(); // Clear console for animation
    Console.WriteLine("\nTower of Hanoi - ASCII Visualization\n");

    // Loop through each level from top to bottom
    for (int level = n - 1; level >= 0; level--)
    {
        foreach (char peg in new[] { 'L', 'M', 'R' })
        {
            Stack<int> pegStack = pegs[peg]; // Get the peg stack

            if (pegStack.Count > level)
            {
                int diskSize = pegStack.ToArray()[pegStack.Count - 1 - level]; // Reverse indexing
                Console.Write(new string(' ', n - diskSize)); // Left padding
                Console.Write(new string('=', diskSize * 2)); // Disk size
                Console.Write(new string(' ', n - diskSize)); // Right padding
            }
            else
            {
                Console.Write(new string(' ', n) + "|" + new string(' ', n)); // Empty peg
            }
            Console.Write("\t");
        }
        Console.WriteLine();
    }

    Console.WriteLine("  L\t\t  M\t\t  R"); // Peg labels
    Thread.Sleep(800); // Pause for animation effect
    }


    // Moves a disk and updates the visualization
   public static void MoveDisk(int disk, char from, char to)
   {
    Console.WriteLine($"DEBUG: Moving disk {disk} from {from} to {to}"); // Debugging log

    if (!pegs.ContainsKey(from) || !pegs.ContainsKey(to))
    {
        Console.WriteLine($"[ERROR] Invalid move: {from} to {to}");
        return; // Prevent crash
    }

    pegs[to].Push(pegs[from].Pop()); // Move disk
    Console.WriteLine($"Move disk {disk} from {from} to {to}");
    DrawPegs(pegs['L'].Count + pegs['M'].Count + pegs['R'].Count); // Redraw after move
    }


}
