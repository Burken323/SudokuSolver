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
            SudokuMethods game = new SudokuMethods("003020600900305001001806400" +
                                                   "008102900700000008006708200" +
                                                   "002609500800203009005010300");
            //game.PrintPuzzle();
            game.PuzzleSolver(1, game.puzzle, game.originPuzzle);
            //game.PuzzleSolver(1, game.puzzle, game.originPuzzle);
            game.PrintPuzzle();
            Console.ReadKey();
            //game.PrintBoard();
        }
    }
}
