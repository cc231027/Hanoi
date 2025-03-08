```md
# Tower of Hanoi Report

## 1. Introduction
The **Tower of Hanoi** is a puzzle that consists of three pegs (`L`, `M`, and `R`) and several disks of different sizes. The goal is to move all the disks from the **Left Peg (`L`)** to the **Right Peg (`R`)**, following these rules:

1. You can move **only one disk at a time**.
2. A **larger disk cannot be placed on top of a smaller disk**.
3. The **Middle Peg (`M`)** can be used as an extra space to hold disks.

This project solves the Tower of Hanoi problem in **two ways**:
- **Recursively**
- **Iteratively (Using a Stack)**  

It also includes **ASCII art visualization**, which shows how the disks move.

---

## 2. Recursive Solution
In the **recursive** method, the problem is broken into smaller steps:

1. Move `n-1` disks from **L** to **M** (using **R** as a helper).
2. Move the **largest disk** from **L** to **R**.
3. Move `n-1` disks from **M** to **R** (using **L** as a helper).

### **How It Works**
```csharp
class RecursiveHanoi
{
    public static void Solve(int n, char from, char to, char aux)
    {
        if (n == 1)
        {
            HanoiVisualizer.MoveDisk(n, from, to);
            return;
        }

        Solve(n - 1, from, aux, to);
        HanoiVisualizer.MoveDisk(n, from, to);
        Solve(n - 1, aux, to, from);
    }
}
```
This function keeps **calling itself** until all disks are moved.

---

## 3. Iterative Solution (Using Stack)
Since **recursion** uses the system's **call stack**, we can **simulate recursion** using an **explicit stack**.

### **How It Works**
- Instead of calling a function **recursively**, we store **each move** in a **stack**.
- We then **process moves one by one**.
- This ensures we follow the correct Tower of Hanoi sequence.

### **Code**
```csharp
class IterativeHanoi
{
    class Move { public int Disk; public char From, To; }

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
                        'L';

            if (disk == 1)
                HanoiVisualizer.MoveDisk(disk, src, dest);
            else
            {
                stack.Push(new Move { Disk = disk - 1, From = temp, To = dest });
                stack.Push(new Move { Disk = 1, From = src, To = dest });
                stack.Push(new Move { Disk = disk - 1, From = src, To = temp });
            }
        }
    }
}
```
This **avoids recursion** while keeping the **correct order of moves**.

---

## 4. ASCII Art Visualization
To make the output **more interactive**, we use **ASCII art** to show the towers.

### **How It Works**
1. Each peg (`L`, `M`, `R`) is represented as a **stack**.
2. After **every move**, we **clear the console** and **redraw the towers**.
3. Disks are displayed using `=` symbols.

### **Code**
```csharp
class HanoiVisualizer
{
    private static Dictionary<char, Stack<int>> pegs = new Dictionary<char, Stack<int>>();

    public static void InitializePegs(int n)
    {
        pegs.Clear();
        pegs['L'] = new Stack<int>();
        pegs['M'] = new Stack<int>();
        pegs['R'] = new Stack<int>();

        for (int i = n; i >= 1; i--)
        {
            pegs['L'].Push(i);
        }

        DrawPegs(n);
    }

    public static void DrawPegs(int n)
    {
        Console.Clear();
        Console.WriteLine("\nTower of Hanoi - ASCII Visualization\n");

        for (int level = n - 1; level >= 0; level--)
        {
            foreach (char peg in new[] { 'L', 'M', 'R' })
            {
                if (pegs[peg].Count > level)
                {
                    int diskSize = pegs[peg].ToArray()[pegs[peg].Count - 1 - level];
                    Console.Write(new string(' ', n - diskSize));
                    Console.Write(new string('=', diskSize * 2));
                    Console.Write(new string(' ', n - diskSize));
                }
                else
                {
                    Console.Write(new string(' ', n) + "|" + new string(' ', n));
                }
                Console.Write("\t");
            }
            Console.WriteLine();
        }

        Console.WriteLine("  L\t\t  M\t\t  R");
        Thread.Sleep(500);
    }

    public static void MoveDisk(int disk, char from, char to)
    {
        pegs[to].Push(pegs[from].Pop());
        Console.WriteLine($"Move disk {disk} from {from} to {to}");
        DrawPegs(pegs['L'].Count + pegs['M'].Count + pegs['R'].Count);
    }
}
```
### **Expected Output**
When we run:
```sh
dotnet run -Recursive 4
```
or
```sh
dotnet run -Iterative 4
```
It prints moves **while updating the ASCII tower**.

---

## 5. Challenges We Faced
1. **Stacking Disks in the Wrong Order**  
   - Initially, the pegs **displayed the disks in reverse order** (smallest at the bottom).  
   - We **fixed this** by correctly indexing the stack.

2. **Incorrect Moves in Iterative Solution**  
   - The auxiliary peg calculation was incorrect.  
   - We fixed this by properly determining the **helper peg**.

3. **Console Not Updating Properly**  
   - The ASCII visualization was **not clearing correctly**.  
   - We **used `Console.Clear()`** to refresh the display.

---

## 6. Conclusion
- **Recursive and Iterative solutions work correctly.**
- **ASCII visualization updates dynamically.**
- **Challenges were solved, and the project meets all requirements.**

---
