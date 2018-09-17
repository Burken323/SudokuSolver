using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduku
{
    class Program
    {
        static void Main(string[] args)
        {
            /*SudokuMethods game = new SudokuMethods("003020600900305001001806400" +
                                                   "008102900700000008006708200" +
                                                   "002609500800203009005010300");*/
            //SudokuMethods game = new SudokuMethods("060090020100000000070001800015300002000604000800005430003400050000000009050070060");
            SudokuMethods game = new SudokuMethods("800000000003600000070090200050007000000045700000100030001000068008500010090000400");
            //game.PrintPuzzle();
            //game.PuzzleSolverEasy();
            game.Solve();
            //game.PrintPuzzle(game.puzzle);
            game.PrintPuzzle(game.puzzleComplete);
            
            
            
            //game.PrintPuzzle(game.puzzleComplete);
            
            Console.ReadKey();
            //game.PrintBoard();
        }
    }
}
