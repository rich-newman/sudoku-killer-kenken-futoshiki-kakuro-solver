## Description

A generic solver for Sudoku, Futoshiki, Killer and other puzzles based on grids of numbers with constraints.

Note that whilst this code can solve the puzzle types listed above it has no nice user interface.  In particular you need to set up a new puzzle to solve in code.

## Background

On a long flight recently I picked up a paper copy of the UK Times.  This has several pages of puzzles every day and I entertained myself by attempting to solve them.

The Times has several Sudokus daily.  It also has several other very similar puzzle types where the solver is expected to fill in a grid of numbers based on certain constraints.

Having tried several of these I realized that these were all basically the same puzzle, and that they lent themselves to a generic solution which could be implemented in code.

So as a holiday project I decided to write a solver.  I wanted to use an OO language as it seemed to fit the problem quite well, so used C#.

This code is the result of that project.

## Operation

The Harness project shows how to set up a puzzle and output the solution, in file Program.cs.

For a Sudoku this involves instantiating the Sudoku class, for example Sudoku sudoku = new Sudoku().

Then call the SetValue method on it repeatedly to set up any values that are in the initial grid.  The parameters are X-coordinate, Y-coordinate, value.  The coordinates run from 0-8.

So for example sudoku.SetValue(0, 0, 4) sets the top left cell to contain 4.  sudoku.SetValue(1, 0, 9) sets the cell to the right of that to 9.

To solve the puzzle call sudoku.Solve().  After this the results will be in sudoku.Values, which is a 9x9 integer array as you'd expect.  These can be output to the console window with Solver.Console.Show(sudoku.Values).

