## Description

A generic solver for Sudoku, Futoshiki, Killer, KenKen, Kakuro and other puzzles based on grids of numbers with constraints.

The code is structured in such a way that it should be relatively easy to add a new type of constraint-based grid puzzle to the system.

Note that whilst this code can solve the puzzle types listed above it has no nice user interface.  In particular you have to use code to set up a new puzzle to be solved.

## Background

On a long flight recently I picked up a paper copy of the UK Times.  This has many pages of puzzles every day and I entertained myself by attempting to solve them.

The Times has several Sudokus daily.  It also has a few other very similar puzzle types where the solver is expected to fill in a grid of numbers based on certain constraints.

Having tried several of these I realized that these were all basically the same puzzle, and that they lent themselves to a generic solution which could be implemented in code.

So I decided to write a solver.  I wanted to use an OO language as it seemed to fit the problem quite well, so used C#.

This code is the result of that project.

## Operation

The Harness project shows how to set up a puzzle and output the solution, in file Program.cs.

For a Sudoku this involves instantiating the Sudoku class, for example 
``` csharp
Sudoku sudoku = new Sudoku();
```

Then call the SetValue method on it repeatedly to set up any values that are in the initial grid.  The parameters are X-coordinate, Y-coordinate, value.  The coordinates run from 0-8.

So for example 

``` csharp
sudoku.SetValue(0, 0, 4); 
```
sets the top left cell to contain 4. 
 
``` csharp
sudoku.SetValue(1, 0, 9);
```
sets the cell to the right of that to 9.

To solve the puzzle call
``` csharp
sudoku.Solve();
```
After this the results will be in sudoku.Values, which is a 9x9 integer array as you'd expect.  These can be output to the console window with 
``` csharp
Solver.Console.Show(sudoku.Values);
```

## Performance

This code has not been highly optimized.  However it's fairly efficient.  On my slow laptop most puzzles take at most a few hundred milliseconds.  The tough Kakuro is taking about 3 seconds.