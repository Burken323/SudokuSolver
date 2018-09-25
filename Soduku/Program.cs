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
            //SudokuMethods game = new SudokuMethods("003020600900305001001806400" + "008102900700000008006708200" + "002609500800203009005010300");
            //SudokuMethods game = new SudokuMethods("060090020100000000070001800015300002000604000800005430003400050000000009050070060");
            //SudokuMethods game = new SudokuMethods("800000000003600000070090200050007000000045700000100030001000068008500010090000400");
            //SudokuMethods game = new SudokuMethods("037060000205000800006908000" + "000600024001503600650009000" + "000302700009000402000050360");
            //SudokuMethods game = new SudokuMethods("000000000000000000000000000000000000000010000000000000000000000000000000000000000");
            SudokuMethods game = new SudokuMethods("900040000000010200370000005000000090001000400000705000000020100580300000000000000");
            //SudokuMethods game = new SudokuMethods("000000000000003085001020000000507000004000100090000000500000073002010000000040009");
            game.Solve();
            //SuperEpicMegaNiceGame semng = new SuperEpicMegaNiceGame();
            //semng.startGame();
            
            Console.ReadKey();
        }
    }
}
