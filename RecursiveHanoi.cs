using System;

class RecursiveHanoi
{
    public static void Solve(int n, char from, char to, char aux)
    {
        // Base case: If only one disk, move it directly
        if (n == 1)
        {
            HanoiVisualizer.MoveDisk(n, from, to);
            return;
        }

        // Move (n-1) disks from 'from' peg to 'aux' peg
        Solve(n - 1, from, aux, to);

        // Move the nth (largest) disk from 'from' peg to 'to' peg
        HanoiVisualizer.MoveDisk(n, from, to); 

        // Move (n-1) disks from 'aux' peg to 'to' peg
        Solve(n - 1, aux, to, from);
    }
}
