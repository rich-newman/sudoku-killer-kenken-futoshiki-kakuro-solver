using Solver.Constraints;
using Solver.Puzzles;
using System.Collections.Generic;

namespace Solver
{
    public class Solver
    {
        private Puzzle puzzle;
        public Solver(Puzzle puzzle) { this.puzzle = puzzle; }

        public void Solve()
        {
            if (!ValidateValues()) throw new System.Exception("Invalid start up grid");
            bool result = SolveCurrentGrid();
            if (!result) throw new System.Exception("Grid cannot be solved");
        }

        // Any grid passed to this has to be valid: it doesn't check validity of the base grid it's using
        private bool SolveCurrentGrid()
        {
            SetAllForcedValues(out bool isConflictFound, out bool isSolveFinished, out int emptyCellX, out int emptyCellY);
            if (isSolveFinished) return true;  // TODO pretty sure isSolveFinished can be replaced by emptyCellX == -1, although at present that can be true if we've found a conflict
            if (isConflictFound) return false;
            //Output.Show(puzzle.Values); // Slows everything down, but useful for seeing progress if it's not working
            int[,] currentValues = (int[,])puzzle.Values.Clone();
            for (int guess = 1; guess <= puzzle.MaxValue; guess++)
            {
                puzzle.Values[emptyCellX, emptyCellY] = guess;
                if (!ValidateValues(emptyCellX, emptyCellY)) continue;
                if (SolveCurrentGrid()) return true;
                // We have a conflict - we may have forced some values in the call to SolveCurrentGrid, so restore
                puzzle.Values = (int[,])currentValues.Clone();
            }
            // We haven't found a valid solution by guessing this cell's value, so set it back to empty
            puzzle.Values[emptyCellX, emptyCellY] = 0;
            return false;
        }

        private void SetAllForcedValues(out bool isConflictFound, out bool isSolveFinished, out int emptyCellX, out int emptyCellY)
        {
            bool isForcedValueFound = true;
            do
            {
                isForcedValueFound = SetForcedValue(out isConflictFound, out isSolveFinished, out emptyCellX, out emptyCellY);
            } while (isForcedValueFound && !isSolveFinished && !isConflictFound);
        }

        private bool SetForcedValue(out bool isConflictFound, out bool isSolveFinished, out int emptyCellX, out int emptyCellY)
        {
            emptyCellX = emptyCellY = -1;
            isConflictFound = isSolveFinished = false;
            for (int y = 0; y < puzzle.GridSize; y++)
            {
                for (int x = 0; x < puzzle.GridSize; x++)
                {
                    if (puzzle.Values[x, y] == 0)
                    {
                        int value = -1;
                        for (int possibleValue = 1; possibleValue <= puzzle.MaxValue; possibleValue++)
                        {
                            puzzle.Values[x, y] = possibleValue;
                            if (ValidateValues(x, y))
                            {
                                if (value != -1)
                                {
                                    // There are two values that can go in this cell and keep the grid valid: there's no forced value here
                                    // When we started this method this cell was empty, and it's going to stay that way: record if first empty cell
                                    if (emptyCellX == -1) { emptyCellX = x; emptyCellY = y; }
                                    value = 0;
                                    break;
                                }
                                value = possibleValue;
                            }
                        }
                        // No value can be found that can provide a solution to the grid: we have a conflict
                        if (value == -1) { isConflictFound = true; return false; }
                        // We've either found one and only one value that can go in this cell and keep the grid valid
                        // (in value) or we've found two possible values, in which case value==0 and we set cell back to empty
                        puzzle.Values[x, y] = value;
                        if (value != 0) return true;
                    }
                }
            }
            if (emptyCellX == -1) isSolveFinished = true; // No empty cells
            return false;
        }

        public bool ValidateValues()
        {
            for (int y = 0; y < puzzle.GridSize; y++)
            {
                for (int x = 0; x < puzzle.GridSize; x++)
                {
                    bool result = ValidateValues(x, y);
                    if (!result) return false;
                }
            }
            return true;
        }

        public bool ValidateValues(int x, int y)
        {
            foreach (Constraint constraint in puzzle.Constraints)
            {
                bool result = constraint.Evaluate(puzzle, x, y);
                if (!result) return false;
            }
            return true;
        }
    }
}
