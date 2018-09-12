using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduku
{
    class SudokuMethods
    {
        
        /**
         * Checks if the number exists in that row.
         */
        public static bool FindInRow(char num, int col, char[,] puzzle)
        {
            int length = puzzle.GetUpperBound(1);
            for (int row = 0; row <= length; row++)
            {
                if (num == puzzle[col, row])
                {
                    return true;
                }
            }
            return false;
        }

        /**
         * Checks if the number exists in that column.
         */
        public static bool FindInCol(char num, int row, char[,] puzzle)
        {
            int length = puzzle.GetUpperBound(0);
            for (int col = 0; col <= length; col++)
            {
                if (num == puzzle[col, row])
                {
                    return true;
                }
            }
            return false;

        }

        /**
         * Returns all the invalid numbers for the position.
         */
        public void GetInvalidNumbers()
        {

        }

        /**
         * Returns an array with the values in the puzzle's box.
         */
        private static List<char> FindNumbers(int start, int stop, char[,] puzzle)
        {
            List<char> boxContains = new List<char>();
            for (int col = start; col < stop; col++)
            {
                for (int row = start; row < stop; row++)
                {
                    if(!puzzle[col,row].Equals(' '))
                    {
                        boxContains.Add(puzzle[col, row]);
                        
                    }
                }
            }
            return boxContains;
        }

        /**
         * Returns all the valid numbers in the current 3x3 area.
         */
        private static List<char> GetValidNumber(int x, int y, char[,] puzzle)
        {
            List<char> boxContains = new List<char>();
            if (x < 3 && y < 3)
            {
                 boxContains = FindNumbers(0, 3, puzzle);
            }
            else if((x > 2 && x < 5) && (y > 2 && y < 5))
            {
                boxContains = FindNumbers(3, 5, puzzle);
            }
            else
            {
                boxContains = FindNumbers(6, 9, puzzle);
            }
            return boxContains;
        }

        /**
         * Returns true if puzzle is complete.
         */
        public void CheckIfComplete()
        {

        }

        /**
         * Returns true/false depinding on the squares status.
         */
        public void CheckIfValidSquare()
        {
            for ()
            {
                for ()
                {

                }
            }
        }

        /**
         * Solver method for easy sudoku-puzzle.
         */
        public static void PuzzleSolverEasy(char[,] puzzle)
        {
            //Loopa och sätt in värden som endast kan vara på den positionen.
            List<char> boxContains = new List<char>();
            int colLength = puzzle.GetUpperBound(0);
            int rowLength = puzzle.GetUpperBound(1);
            int startNum = 1;
            string start = startNum.ToString();
            bool puzzleNotSolved = true;
            while (puzzleNotSolved)
            {
                for(int cols = 0; cols <= colLength; cols++)
                {
                    for (int rows = 0; rows <= rowLength; rows++)
                    {
                        boxContains = GetValidNumber(rows, cols, puzzle);
                        if (!FindInRow(start[0], cols, puzzle) && !FindInCol(start[0], rows, puzzle) && puzzle[cols, rows].Equals(' ') && !boxContains.Contains(start[0]))
                        {
                            puzzle[cols, rows] = start[0];
                        }
                    }
                }
            }
        }

        /**
         * Solver method for the sudoku-puzzle.
         */
        public static void PuzzleSolver(int startNum, char[,] puzzle, char[,] originPuzzle)
        {
            string start = startNum.ToString();
            int colLength = puzzle.GetUpperBound(0);
            int rowLength = puzzle.GetUpperBound(1);
            List<char> boxContains = new List<char>();
            for(int cols = 0; cols <= colLength; cols++)
            {
                for(int rows = 0; rows <= rowLength; rows++)
                {
                    boxContains = GetValidNumber(rows, cols, puzzle);
                    if (!FindInRow(start[0], cols, puzzle) && !FindInCol(start[0], rows, puzzle) && puzzle[cols,rows].Equals(' ') && !boxContains.Contains(start[0]))
                    {
                        puzzle[cols, rows] = start[0];
                        PuzzleSolver(1, puzzle, originPuzzle);
                    }
                    else if(int.Parse(start) != 10)
                    {
                        PuzzleSolver(startNum + 1, puzzle, originPuzzle);
                    }
                }
            }
            //set puzzle to originPuzzle.
            puzzle = originPuzzle;
            PuzzleSolver(startNum, originPuzzle, originPuzzle);
        }


    }
}
