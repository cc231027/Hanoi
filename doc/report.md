# 📜 Tower of Hanoi Report

## 1. Introduction
The **Tower of Hanoi** is a classic puzzle that involves three pegs (**L**, **M**, and **R**) and a set of disks. The goal is to move all disks from the **Left Peg (L)** to the **Right Peg (R)** while following these rules:
1. Only **one disk** can be moved at a time.
2. A **larger disk cannot be placed on top of a smaller disk**.
3. The **Middle Peg (M)** can be used as an auxiliary peg.

In this project, I implemented **two solutions**:
- **Recursive Solution**
- **Iterative Solution (Using a Stack)**  

Additionally, I added **ASCII art visualization** to show the movement of disks in the console.

---

## 2. Recursive Solution
The recursive approach follows a **divide-and-conquer** strategy:
1. Move `n-1` disks from **L** → **M** (using **R** as a helper).
2. Move the **largest disk** from **L** → **R**.
3. Move `n-1` disks from **M** → **R** (using **L** as a helper).

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
This method **breaks the problem into smaller parts** until all disks are moved.

---

## 3. Iterative Solution (Using Stack)
Instead of using **recursion**, I simulate it with a **stack** to keep track of moves.

### **How It Works**
- I push all moves into a **stack** and process them **one by one**.
- The **stack follows the recursive order**, ensuring correct disk movement.
- This prevents **stack overflow** when dealing with large `n`.

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
This solution **removes recursion** while keeping the moves **in the correct order**.

---

## 4. ASCII Art Visualization
To **enhance the experience**, we added **ASCII art** to **show the tower movements**.

### **How It Works**
1. Each peg (**L, M, R**) is stored as a **Stack<int>**.
2. Every time a disk moves, the **console is updated** with `Console.Clear()`.
3. Disks are displayed using **`=` symbols** for visualization.

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
        Thread.Sleep(800);
    }

    public static void MoveDisk(int disk, char from, char to)
    {
        Console.WriteLine($"Move disk {disk} from {from} to {to}");
        pegs[to].Push(pegs[from].Pop());
        DrawPegs(pegs['L'].Count + pegs['M'].Count + pegs['R'].Count);
    }
}
```
### **Expected Output**
When I run:
```sh
dotnet run -Recursive 4
```
or
```sh
dotnet run -Iterative 4
```
It prints **each move** while dynamically **updating the tower in ASCII**.

---

## 5. Challenges Faced
### ❌ **1. Incorrect Disk Stacking**
- At first, disks were displayed **in the wrong order** (smallest at the bottom).
- **Fix:** I adjusted the **indexing** when drawing the pegs.

### ❌ **2. Wrong Moves in the Iterative Solution**
- The **auxiliary peg was being assigned incorrectly**.
- **Fix:** I correctly determined the **helper peg** based on movement direction.

### ❌ **3. Console Output Not Refreshing Properly**
- The **console was not updating** between moves.
- **Fix:** I added `Console.Clear()` and `Thread.Sleep(800)` to refresh the display.

---

## 6. Conclusion
- ✅ **Both Recursive and Iterative solutions work correctly.**
- ✅ **The ASCII visualization updates dynamically.**
- ✅ **Fixed multiple bugs to ensure correct disk movement.**
- ✅ **This project successfully solves the Tower of Hanoi problem! 🎉**

---
## **7. How to Run the Project**
### **Prerequisites**
- Install **.NET SDK** from [here](https://dotnet.microsoft.com/download)
- Open the terminal in **VS Code** or **Command Prompt**

### **Run Recursive Solution**
```sh
dotnet run -Recursive 4
```

### **Run Iterative Solution**
```sh
dotnet run -Iterative 4
```

---