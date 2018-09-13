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
        private static List<char> FindNumbers(int startRow, int stopRow, int startCol, int stopCol, char[,] puzzle)
        {
            List<char> boxContains = new List<char>();
            for (int col = startCol; col < stopCol; col++)
            {
                for (int row = startRow; row < stopRow; row++)
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
        public List<char> GetValidNumbers(int x, int y, char[,] puzzle)
        {
            List<char> boxContains = new List<char>();
            //Ruta 0.
            if (x < 3 && y < 3)
            {
                boxContains = FindNumbers(0, 3, 0, 3, puzzle);
            }
            //Ruta 1,0.
            else if (x < 3 && (y > 2 %% y < 5))
            {
                boxContains = FindNumbers(0, 3, 3, 5, puzzle);
            }
            //Ruta 2,0.
            else if(x < 3 && (y > 5 && y < 9))
            {
                boxContains = FindNumbers(0, 3, 5, 9, puzzle);
            }
            //Ruta 0,1.
            else if ((x > 2 && x < 5) && y < 3)
            {
                boxContains = FindNumbers(3, 5, 0, 3, puzzle);
            }
            //MittenRutan 1,1.
            else if ((x > 2 && x < 5) && (y > 2 && y < 5))
            {
                boxContains = FindNumbers(3, 5, 3, 5, puzzle);
            }
            //Ruta 2,1.
            else if ((x > 2 && x < 5) && (y > 5 && y < 9))
            {
                boxContains = FindNumbers(3, 5, 5, 9, puzzle);
            }
            //Ruta 0,2.
            else if((x > 5 && x < 9) && y < 3)
            {
                boxContains = FindNumbers(5, 9, 0, 3, puzzle);
            }
            //Ruta 1,2.
            else if ((x > 5 && x < 9) && (y > 2 && y < 5))
            {
                boxContains = FindNumbers(5, 9, 3, 5, puzzle);
            }
            //Ruta 2,2.
            else
            {
                boxContains = FindNumbers(5, 9, 5, 9, puzzle);
            }
            return boxContains;
        }

        /**
         * Returns true if puzzle is complete.
         */
        public bool CheckIfComplete(char[,] puzzle)
        {
            int colLength = puzzle.GetUpperBound(0);
            int rowLength = puzzle.GetUpperBound(1);
            int rowTotal = 0;
            for (int cols = 0; cols <= colLength; cols++)
            {
                rowTotal = 0;
                for (int rows = 0; rows <= rowLength; rows++)
                {
                    rowTotal += int.Parse(puzzle[cols, rows].ToString());
                }
                if(rowTotal != 45)
                {
                    return false;
                }
            }
            return true;
        }

        /**
         * Returns true/false depinding on the squares status.
         */
        public bool CheckIfValidSquare(int x, int y, char[,] puzzle)
        {
            List<char> contents = new List<char>();
            contents = GetValidNumbers(x, y, puzzle);
            for (int i = 1; i < 10; i++)
            {
                string temp = i.ToString();
                if (!contents.Contains(temp[0]))
                {
                    return false;
                }
            }
            return true;
        }

        /**
         * Solver method for easy sudoku-puzzle.
         */
        public void PuzzleSolverEasy(char[,] puzzle)
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
                        if(CheckIfValidSquare(rows, cols, puzzle))
                        {
                            continue;
                        }
                        boxContains = GetValidNumbers(rows, cols, puzzle);
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
        public void PuzzleSolver(int startNum, char[,] puzzle, char[,] originPuzzle)
        {
            string start = startNum.ToString();
            int colLength = puzzle.GetUpperBound(0);
            int rowLength = puzzle.GetUpperBound(1);
            List<char> boxContains = new List<char>();
            for(int cols = 0; cols <= colLength; cols++)
            {
                for(int rows = 0; rows <= rowLength; rows++)
                {
                    if (CheckIfValidSquare(rows, cols, puzzle))
                    {
                        continue;
                    }
                    boxContains = GetValidNumbers(rows, cols, puzzle);
                    if (!FindInRow(start[0], cols, puzzle) && !FindInCol(start[0], rows, puzzle) && puzzle[cols,rows].Equals(' ') && !boxContains.Contains(start[0]))
                    {
                        puzzle[cols, rows] = start[0];
                        PuzzleSolver(1, puzzle, originPuzzle);
                    }
                    else if(int.Parse(start) != 10)
                    {
                        PuzzleSolver(startNum + 1, puzzle, originPuzzle);
                    }
                    //Need fix here.
                    else if(int.Parse(start) == 10)
                    {
                        rows--;
                        int num = int.Parse(puzzle[cols, rows].ToString());
                        num++;
                        if(num == 10)
                        {
                            num = 1;
                        }
                        string temp = num.ToString();
                        while (boxContains.Contains(num))
                        {
                            num++;
                        }
                        string number = num.ToString();
                        puzzle[cols, rows] = number[0];
                    }
                    else
                    {
                        puzzle = originPuzzle;
                        PuzzleSolver(startNum, originPuzzle, originPuzzle);
                    }
                }
            }
        }


    }
}
