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
         * Returns coordinates of that number.
         */
        public void GetCoordinates()
        {

        }

        /**
         * Returns all the valid numbers in the current 3x3 area.
         */
        public void GetValidNumber()
        {

        }

        /**
         * Returns true/false depinding on the squares status.
         */
        public void CheckIfValidSquare()
        {

        }

        /**
         * Solver method for the sudoku-puzzle.
         */
         public static void PuzzleSolver(int start, char[,] puzzle, char[,] originPuzzle)
         {
            int colLength = puzzle.GetUpperBound(0);
            int rowLength = puzzle.GetUpperBound(1);
            for(int cols = 0; cols <= colLength; cols++)
            {
                for(int rows = 0; rows <= rowLength; rows++)
                {
                    if (!FindInRow((char)start, cols, puzzle) && !FindInCol((char)start, rows, puzzle) && puzzle[cols,rows].Equals(' '))
                    {
                        puzzle[cols, rows] = (char)start;
                        PuzzleSolver(1, puzzle, originPuzzle);
                    }
                    else if(start != 10)
                    {
                        PuzzleSolver(start + 1, puzzle, originPuzzle);
                    }
                }
            }
            //set puzzle to originPuzzle.
            puzzle = originPuzzle;
            PuzzleSolver(start, originPuzzle, originPuzzle);
         }


    }
}
