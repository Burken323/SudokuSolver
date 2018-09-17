﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduku
{
    class SudokuMethods
    {
        public char[,] puzzle = new char[9,9];
        public char[,] puzzleComplete = new char[9, 9];
        public int testSolution = 0;

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
            //originPuzzle = puzzle;
        }

        public void PrintPuzzle(char[,] puzzle)
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
        public List<char> CheckForInputNumbers(int y, int x)
        {
            List<char> inputNumbers = new List<char>();
            List<char> boxContains = new List<char>();
            boxContains = GetValidNumbers(y, x);

            for (int i = 1; i < 10; i++)
            {
                string num = i.ToString();
                if (!FindInRow(num[0], y) && !FindInCol(num[0], x) && !boxContains.Contains(num[0]))
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
            
            
            bool puzzleNotSolved = true;
            while (puzzleNotSolved)
            {

                if (CheckIfComplete())
                {
                    
                    Console.WriteLine("Klart!");
                    break;
                }
                
                for(int rows = 0; rows <= rowLength; rows++)
                {
                    for (int cols = 0; cols <= colLength; cols++)
                    {
                        
                        inputNumbers = CheckForInputNumbers(rows, cols);
                        boxContains = GetValidNumbers(rows, cols);
                        
                        if (puzzle[rows, cols].Equals('-') && (inputNumbers.Count == 1))
                        {
                            puzzle[rows, cols] = inputNumbers.ElementAt(0);
                            Console.WriteLine();
                            PrintPuzzle(puzzle);
                            Console.Clear();
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
        public bool PuzzleSolver(int y, int x, char[,] puzzle)
        {
            
            int colLength = puzzle.GetUpperBound(0);
            int rowLength = puzzle.GetUpperBound(1);
            List<char> boxContains = new List<char>();
            List<char> inputNumbers = new List<char>();
            if (CheckIfComplete())
            {
                Console.WriteLine("Klart!");
                Console.ReadKey();

            }
            /*
            for (int rows = 0; rows <= rowLength; rows++)
            {
                for (int cols = 0; cols <= colLength; cols++)
                {
                    boxContains = GetValidNumbers(rows, cols);
                    inputNumbers = CheckForInputNumbers(rows, cols);

                    if (puzzle[rows, cols].Equals('-') && (inputNumbers.Count == 1))
                    {
                        puzzle[rows, cols] = inputNumbers.ElementAt(0);
                        PrintPuzzle();
                        
                    }
                }
            }
            */
            boxContains.Clear();
            inputNumbers.Clear();
            //Loopar 1-9 och testar att sätta in ett value.
            for(int testValue = 1; testValue < 10; testValue++)
            {
                boxContains = GetValidNumbers(y, x);
                inputNumbers = CheckForInputNumbers(y, x);
                string tempVal = testValue.ToString();
                //Om testvärdet är ett av siffrorna som får läggas till.
                if(inputNumbers.Contains(tempVal[0]))
                {
                    puzzle[y, x] = tempVal[0];
                    //PrintPuzzle(puzzle);
                    boxContains.Clear();
                    inputNumbers.Clear();
                    //Kontrollera om inputen fungerar.
                    if (CheckIfInputWorks())
                    {
                        //Om hela fungerar så kopiera lösningen.
                        if (testSolution == 0)
                        {
                            for(int row = 0; row <= puzzle.GetUpperBound(0); row++)
                            {
                                for(int col = 0; col <= puzzle.GetUpperBound(1); col++)
                                {
                                    puzzleComplete[row, col] = puzzle[row, col];
                                    
                                }
                            }
                            Console.WriteLine("Hittade en lösning!");
                            PrintPuzzle(puzzle);
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

        public bool CheckIfInputWorks()
        {
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
        
        public bool CheckForSolution()
        {
            for(int rows = 0; rows <= puzzle.GetUpperBound(0); rows++)
            {
                for(int cols = 0; cols <= puzzle.GetUpperBound(1); cols++)
                {
                    //Kontrollerar så positionen innehåller tal.
                    if(!puzzle[rows, cols].Equals('-'))
                    {
                        List<char> inputNumbers = new List<char>();
                        
                        inputNumbers = CheckForInputNumbers(rows, cols);
                        
                        //Kontrollerar Rows, cols, samt box för positionen.
                        if (!(inputNumbers.Count != 1))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public void Solve()
        {
            //Kontrollerar så det finns en lösning för pusslet.
            CheckIfInputWorks();
            /*if (CheckForSolution())
            {
                //Startar rekursionen för att lösa pusslet.
                CheckIfInputWorks();
                //return testSolution > 0;
            }
            else
            {
                Console.WriteLine("Pusslet saknar lösning.");
                //return false;
            }*/
        }
        
    }
}


