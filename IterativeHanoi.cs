using System;
using System.Collections.Generic;

class IterativeHanoi
{
    class Move
    {
        public int Disk { get; set; }
        public char From { get; set; }
        public char To { get; set; }
    }

    public static void Solve(int n, char from, char to, char aux)
    {
        Stack<Move> stack = new Stack<Move>();
        stack.Push(new Move { Disk = n, From = from, To = to });

        while (stack.Count > 0)
        {
            Move move = stack.Pop();
            int disk = move.Disk;
            char src = move.From;
            char dest = move.To;
            char temp = (src == 'L' && dest == 'R') || (src == 'R' && dest == 'L') ? 'M' :
                        (src == 'L' && dest == 'M') || (src == 'M' && dest == 'L') ? 'R' :
                        'L'; // Correctly assign auxiliary peg

            if (disk == 1)
            {
                HanoiVisualizer.MoveDisk(disk, src, dest); // Corrected
            }
            else
            {
                stack.Push(new Move { Disk = disk - 1, From = temp, To = dest });
                stack.Push(new Move { Disk = 1, From = src, To = dest }); // Push base case move
                stack.Push(new Move { Disk = disk - 1, From = src, To = temp });
            }
        }
    }
}
