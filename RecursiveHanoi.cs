using System;

class RecursiveHanoi
{
    public static void Solve(int n, char from, char to, char aux)
    {
        if (n == 1)
        {
            HanoiVisualizer.MoveDisk(n, from, to); // Corrected
            return;
        }

        Solve(n - 1, from, aux, to);
        HanoiVisualizer.MoveDisk(n, from, to); // Corrected
        Solve(n - 1, aux, to, from);
    }
}
