using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduku
{
    class SudokuMethods
    {
        public char[,] puzzle = new char[9,9];
        public char[,] originPuzzle = new char[9, 9];

        public SudokuMethods(string game)
        {
            int index = 0;
            int colLength = puzzle.GetUpperBound(0);
            int rowLength = puzzle.GetUpperBound(1);
            Console.WriteLine("+-----------------------------------+");
            for(int cols = 0; cols <= colLength; cols++)
            {
                Console.Write("|");
                for(int rows = 0; rows <= rowLength; rows++)
                {
                    if (game[index].Equals('0'))
                    {
                        puzzle[cols, rows] = '-';
                        Console.Write(" " + puzzle[cols, rows] + " ");
                    }
                    else
                    {
                        puzzle[cols, rows] = game[index];
                        Console.Write(" " + puzzle[cols, rows] + " ");
                    }
                    Console.Write("|");
                    index++;
                }
                Console.Write("\r\n");
                Console.WriteLine("+-----------------------------------+");
            }
            originPuzzle = puzzle;
        }

        public void PrintPuzzle()
        {
            Console.WriteLine("+---+---+---+---+---+---+---+---+---+");
            for (int cols = 0; cols <= puzzle.GetUpperBound(0); cols++)
            {
                Console.Write("|");
                for(int rows = 0; rows <= puzzle.GetUpperBound(1); rows++)
                {
                    Console.Write(" " + puzzle[cols, rows] + " ");
                    Console.Write("|");
                }
                Console.Write("\r\n");
                Console.WriteLine("+---+---+---+---+---+---+---+---+---+");
            }
        }
       
        /**
         * Checks if the number exists in that column.
         */
        public bool FindInCol(char num, int col)
        {
            int length = puzzle.GetUpperBound(0);
            for (int row = 0; row <= length; row++)
            {
                if (num == puzzle[row, col])
                {
                    return true;
                }
            }
            return false;
        }

        /**
         * Checks if the number exists in that row.
         */
        public bool FindInRow(char num, int row)
        {
            int length = puzzle.GetUpperBound(1);
            for (int col = 0; col <= length; col++)
            {
                if (num == puzzle[row, col])
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
        public List<char> GetValidNumbers(int y, int x)
        {
            List<char> boxContains = new List<char>();
            //Ruta 0.
            if (y < 3 && x < 3)
            {
                boxContains = FindNumbers(0, 3, 0, 3);
            }
            //Ruta 0,1.
            else if (y < 3 && (x > 2 && x < 6))
            {
                boxContains = FindNumbers(0, 3, 3, 6);
            }
            //Ruta 0,2.
            else if(y < 3 && (x > 5 && x < 9))
            {
                boxContains = FindNumbers(0, 3, 6, 9);
            }
            //Ruta 1,0.
            else if ((y > 2 && y < 6) && x < 3)
            {
                boxContains = FindNumbers(3, 6, 0, 3);
            }
            //MittenRutan 1,1.
            else if ((y > 2 && y < 6) && (x > 2 && x < 6))
            {
                boxContains = FindNumbers(3, 6, 3, 6);
            }
            //Ruta 2,1.
            else if ((y > 2 && y < 6) && (x > 5 && x < 9))
            {
                boxContains = FindNumbers(3, 6, 6, 9);
            }
            //Ruta 0,2.
            else if((y > 5 && y < 9) && x < 3)
            {
                boxContains = FindNumbers(6, 9, 0, 3);
            }
            //Ruta 1,2.
            else if ((y > 5 && y < 9) && (x > 2 && x < 6))
            {
                boxContains = FindNumbers(6, 9, 3, 6);
            }
            //Ruta 2,2.
            else
            {
                boxContains = FindNumbers(6, 9, 6, 9);
            }
            return boxContains;
        }

        public List<char> CheckForInputNumbers(int y, int x)
        {
            List<char> inputNumbers = new List<char>();
            for(int i = 1; i < 10; i++)
            {
                string num = i.ToString();
                if ((x - 1) < 0 || (x + 1) > 8 || (y - 1) < 0 || (y + 1) > 8)
                {
                    /*
                    if ((x - 1) < 0 && y > 0 && y < 8)
                    {
                        //Inte göra col
                        if(FindInRow(num[0], y + 1) && FindInRow(num[0], y - 1) && FindInCol(num[0], x + 1) && !FindInRow(num[0], y) && !FindInCol(num[0], x))
                        {
                            inputNumbers.Clear();
                            inputNumbers.Add(num[0]);
                            return inputNumbers;
                        }
                    }
                    else if ((x + 1) > 8 && y < 8 && y > 0)
                    {
                        //Inte göra col
                        if (FindInRow(num[0], y + 1) && FindInRow(num[0], y - 1) && FindInCol(num[0], x - 1) && !FindInRow(num[0], y) && !FindInCol(num[0], x))
                        {
                            inputNumbers.Clear();
                            inputNumbers.Add(num[0]);
                            return inputNumbers;
                        }
                    }
                    else if ((y - 1) < 0 && x > 0 && x < 8)
                    {
                        //Inte göra row
                        if (FindInRow(num[0], y + 1) && FindInCol(num[0], x - 1) && FindInCol(num[0], x + 1) && !FindInRow(num[0], y) && !FindInCol(num[0], x))
                        {
                            inputNumbers.Clear();
                            inputNumbers.Add(num[0]);
                            return inputNumbers;
                        }
                    }
                    else if ((y + 1) > 8 && x > 0 && x < 8)
                    {
                        //Inte göra row
                        if (FindInRow(num[0], y - 1) && FindInCol(num[0], x + 1) && FindInCol(num[0], x - 1) && !FindInRow(num[0], y) && !FindInCol(num[0], x))
                        {
                            inputNumbers.Clear();
                            inputNumbers.Add(num[0]);
                            return inputNumbers;
                        }
                    }*/
                }
                else if (FindInRow(num[0], y + 1) && FindInCol(num[0], x + 1) && FindInRow(num[0], y - 1) && FindInCol(num[0], x - 1) && !FindInRow(num[0], y) && !FindInCol(num[0], x))
                {
                    inputNumbers.Clear();
                    inputNumbers.Add(num[0]);
                    return inputNumbers;
                }
                else if (!FindInRow(num[0], y) && !FindInCol(num[0], x))
                {
                    inputNumbers.Add(num[0]);     
                }
            }
            return inputNumbers;
        }

        /**
         * Returns true if puzzle is complete.
         */
        public bool CheckIfComplete()
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
         * Returns true/false depinding on the squares status.
         */
        public bool CheckIfValidSquare(int y, int x)
        {
            List<char> contents = new List<char>();
            contents = GetValidNumbers(y, x);
            int numberCompare = 1;
            for (int i = 0; i < 9; i++)
            {
                string temp = numberCompare.ToString();
                if (!contents.Contains(temp[0]))
                {
                    return false;
                }
                numberCompare++;
            }
            return true;
        }

        /**
         * Solver method for easy sudoku-puzzle.
         */
        public void PuzzleSolverEasy()
        {
            //Loopa och sätt in värden som endast kan vara på den positionen.
            List<char> boxContains = new List<char>();
            List<char> inputNumbers = new List<char>();
            int colLength = puzzle.GetUpperBound(1);
            int rowLength = puzzle.GetUpperBound(0);
            int startNum = 1;
            string start = startNum.ToString();
            
            bool puzzleNotSolved = true;
            while (puzzleNotSolved)
            {

                if (CheckIfComplete())
                {
                    PrintPuzzle();
                    break;
                }
                
                for(int rows = 0; rows <= rowLength; rows++)
                {
                    for (int cols = 0; cols <= colLength; cols++)
                    {
                        /*
                        if(CheckIfValidSquare(rows, cols))
                        {
                            continue;
                        }*/
                        inputNumbers = CheckForInputNumbers(rows, cols);
                        boxContains = GetValidNumbers(rows, cols);
                        
                        
                        if (puzzle[rows, cols].Equals('-') && (inputNumbers.Count == 1))
                        {
                            
                            if (!boxContains.Contains(inputNumbers.ElementAt(0)))
                            {
                                puzzle[rows, cols] = inputNumbers.ElementAt(0);
                                PrintPuzzle();
                                
                            }
                            
                        }
                        boxContains.Clear(); 
                        inputNumbers.Clear(); 
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
                    boxContains = GetValidNumbers(rows, cols);
                    if (!FindInRow(start[0], cols) && !FindInCol(start[0], rows) && puzzle[cols,rows].Equals(' ') && !boxContains.Contains(start[0]))
                    {
                        puzzle[cols, rows] = start[0];
                        PuzzleSolver(1, puzzle, originPuzzle);
                    }
                    else if(int.Parse(start) != 10)
                    {
                        PuzzleSolver(startNum + 1, puzzle, originPuzzle);
                    }
                    //Need fix here. Flagging need to be added.
                    else if(int.Parse(start) == 10)
                    {
                        while (rows > 0)
                        {
                            rows--;
                            if (puzzle[cols, rows].Equals(' '))
                            {
                                int num = int.Parse(puzzle[cols, rows].ToString());
                                num++;
                                if (num == 10)
                                {
                                    num = 1;
                                }
                                string temp = num.ToString();
                                while (boxContains.Contains(temp[0]))
                                {
                                    num++;
                                }
                                string number = num.ToString();
                                puzzle[cols, rows] = number[0];
                            }
                        }
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
