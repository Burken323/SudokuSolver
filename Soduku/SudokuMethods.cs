using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduku
{
    class SudokuMethods
    {
        private char[,] puzzle = new char[9,9];
        public char[,] puzzleComplete = new char[9, 9];
        private int testSolution = 0;
        
        /**
         * Reads the given string and turns it into a sudokuboard.
         */
        public SudokuMethods(string game)
        {
            int index = 0;
            int colLength = puzzle.GetUpperBound(0);
            int rowLength = puzzle.GetUpperBound(1);
            Console.WriteLine("+---+---+---+---+---+---+---+---+---+");
            for (int rows = 0; rows <= rowLength; rows++)
            {
                Console.Write("|");
                for(int cols = 0; cols <= colLength; cols++)
                {
                    if (game[index].Equals('0'))
                    {
                        puzzle[rows, cols] = '-';
                        Console.Write(" " + puzzle[rows, cols] + " ");
                    }
                    else
                    {
                        puzzle[rows, cols] = game[index];
                        Console.Write(" " + puzzle[rows, cols] + " ");
                    }
                    Console.Write("|");
                    index++;
                }
                Console.Write("\r\n");
                Console.WriteLine("+---+---+---+---+---+---+---+---+---+");
            }
        }

        /**
         * Prints our puzzle.
         */
        private void PrintPuzzle(char[,] puzzle)
        {
            Console.WriteLine("+---+---+---+---+---+---+---+---+---+");
            for (int rows = 0; rows <= puzzle.GetUpperBound(0); rows++)
            {
                Console.Write("|");
                for(int cols = 0; cols <= puzzle.GetUpperBound(1); cols++)
                {
                    Console.Write(" " + puzzle[rows, cols] + " ");
                    Console.Write("|");
                }
                Console.Write("\r\n");
                Console.WriteLine("+---+---+---+---+---+---+---+---+---+");
            }
        }
       
        /**
         * Checks if the number exists in that column.
         */
        private bool FindInCol(char num, int col, int y)
        {
            int length = puzzle.GetUpperBound(0);
            for (int row = 0; row <= length; row++)
            {
                if (num == puzzle[row, col] && (y != row))
                {
                    return true;
                }
            }
            return false;
        }

        /**
         * Checks if the number exists in that row.
         */
        private bool FindInRow(char num, int row, int x)
        {
            int length = puzzle.GetUpperBound(1);
            for (int col = 0; col <= length; col++)
            {
                if (num == puzzle[row, col] && (x != col))
                {
                    return true;
                }
            }
            return false;

        }

        /**
         * Returns an array with the values in the puzzle's box.
         */
        private List<char> FindNumbers(int startRow, int stopRow, int startCol, int stopCol)
        {
            List<char> boxContains = new List<char>();
            for (int row = startRow; row < stopRow; row++)
            {
                for (int col = startCol; col < stopCol; col++)
                {
                    if(!puzzle[row,col].Equals('-'))
                    {
                        boxContains.Add(puzzle[row, col]);
                    }
                }
            }
            return boxContains;
        }

        /**
         * Returns all the valid numbers in the current 3x3 area.
         */
        private List<char> GetValidNumbers(int y, int x)
        {
            List<char> boxContains = new List<char>();
            int boxLength = 3;
            int endValue = puzzle.GetLength(0) / boxLength;
            int startY = y / boxLength;
            startY = startY * boxLength;
            int startX = x / boxLength;
            startX = startX * boxLength;
            boxContains = FindNumbers(startY, startY + endValue, startX, startX + endValue);
            return boxContains;
        }

        /**
         * Gets the valid input numbers for the position.
         */
        private List<char> CheckForInputNumbers(int y, int x)
        {
            List<char> inputNumbers = new List<char>();
            List<char> boxContains = new List<char>();
            boxContains = GetValidNumbers(y, x);

            for (int i = 1; i < 10; i++)
            {
                string num = i.ToString();
                if (!FindInRow(num[0], y, x) && !FindInCol(num[0], x, y) && !boxContains.Contains(num[0]))
                {
                    inputNumbers.Add(num[0]);
                }
            }
            return inputNumbers;
        }

        /**
         * Returns true if puzzle is complete.
         */
        private bool CheckIfComplete()
        {
            int colLength = puzzle.GetUpperBound(0);
            int rowLength = puzzle.GetUpperBound(1);
            int rowTotal = 0;
            for (int rows = 0; rows <= rowLength; rows++)
            {
                rowTotal = 0;
                for (int cols = 0; cols <= colLength; cols++)
                {
                    rowTotal += (int)Char.GetNumericValue(puzzle[rows,cols]);
                }
                if(rowTotal != 45)
                {
                    return false;
                }
            }
            return true;
        }
        
        /**
         * Solver method for easy sudoku-puzzle.
         */
        public void Solve()
        {
            //Loopa och sätt in värden som endast kan vara på den positionen.
            List<char> boxContains = new List<char>();
            List<char> inputNumbers = new List<char>();
            bool puzzleNotSolved = true;
            while (puzzleNotSolved)
            {
                puzzleNotSolved = false;
                if (CheckIfComplete())
                {
                    CopySolution(puzzle);
                    Console.WriteLine("Klart!");
                    break;
                }
                CheckIfAValueCanBeAssigned(ref boxContains, ref inputNumbers, ref puzzleNotSolved);
            }
            RecursionSolve();
        }

        /**
         * Sets number if position is empty and there's only one possible number that can be assigned.
         */
        private void CheckIfAValueCanBeAssigned(ref List<char> boxContains, ref List<char> inputNumbers, ref bool puzzleNotSolved)
        {
            for (int rows = 0; rows <= puzzle.GetUpperBound(0); rows++)
            {
                for (int cols = 0; cols <= puzzle.GetUpperBound(1); cols++)
                {
                    inputNumbers = CheckForInputNumbers(rows, cols);
                    boxContains = GetValidNumbers(rows, cols);

                    if (puzzle[rows, cols].Equals('-') && (inputNumbers.Count == 1))
                    {
                        puzzle[rows, cols] = inputNumbers.ElementAt(0);
                        //PrintPuzzle(puzzle);
                        puzzleNotSolved = true;
                    }
                    boxContains.Clear();
                    inputNumbers.Clear();
                }
            }
        }

        /**
         * Solver method for the sudoku-puzzle.
         */
        private bool PuzzleSolver(int y, int x, char[,] puzzle)
        {
            List<char> boxContains = new List<char>();
            List<char> inputNumbers = new List<char>();
            if (CheckIfComplete())
            {
                Console.WriteLine("Klart!");
                Console.ReadKey();
            }
            //Loopar 1-9 och testar att sätta in ett value.
            for (int testValue = 1; testValue < 10; testValue++)
            {
                boxContains = GetValidNumbers(y, x);
                inputNumbers = CheckForInputNumbers(y, x);
                string tempVal = testValue.ToString();
                //Om testvärdet är ett av siffrorna som får läggas till.
                if (inputNumbers.Contains(tempVal[0]))
                {
                    puzzle[y, x] = tempVal[0];
                    //Kontrollera om inputen fungerar.
                    if (RecursionSolve())
                    {
                        //Om hela fungerar så kopiera lösningen.
                        if (testSolution == 0)
                        {
                            CopySolution(puzzle);
                            Console.WriteLine("Hittade en lösning!");
                            testSolution++;
                            return true;
                        }
                    }
                }
            }
            //Om lösningen inte fungerar så backa ur och sätt pos till tom.
            puzzle[y, x] = '-';
            return false;
        }

        /**
         * Copies the result from the puzzleboard.
         */
        private void CopySolution(char[,] puzzle)
        {
            for (int row = 0; row <= puzzle.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= puzzle.GetUpperBound(1); col++)
                {
                    puzzleComplete[row, col] = puzzle[row, col];
                }
            }
            PrintPuzzle(puzzleComplete);
        }

        /**
         * Checks if the puzzle is valid or not.
         */
        private bool ValidPuzzle()
        {
            for(int rows = 0; rows <= puzzle.GetUpperBound(0); rows++)
            {
                for(int cols = 0; cols <= puzzle.GetUpperBound(1); cols++)
                {
                    if(!puzzle[rows,cols].Equals('-') && (FindInRow(puzzle[rows,cols], rows, cols) || FindInCol(puzzle[rows,cols], cols, rows)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /**
         * Stops the solver if the puzzle is invalid.
         */
        private void PuzzleControl()
        {
            if (!ValidPuzzle())
            {
                Console.WriteLine("Felaktigt pussel!");
                Console.ReadKey();
            }
        }

        /**
         * Solves hard sudoku puzzles using mutual recursion searching for a solution using depth-first.
         */
        private bool RecursionSolve()
        {
            PuzzleControl();
            for (int rows = 0; rows <= puzzle.GetUpperBound(0); rows++)
            {
                for(int cols = 0; cols <= puzzle.GetUpperBound(1); cols++)
                {
                    //Om positionen är tom så returnera PuzzleSolver.
                    if(puzzle[rows, cols].Equals('-'))
                    {
                        return PuzzleSolver(rows, cols, puzzle);
                    }
                }
            }
            return true;
        }
    }
}


