using SudokuSolver.Strategies;
using SudokuSolver.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SudokuMapper sudokuMapper = new SudokuMapper();
                SudokuBoardStateManager sudokuBoardStateManager = new SudokuBoardStateManager();
                SudokuSolverEngine sudokuSolverEngine = new SudokuSolverEngine(sudokuBoardStateManager, sudokuMapper);
                SudokuFileReader sudokuFileReader = new SudokuFileReader();
                SudokuBoardDisplayer sudokuBoardDisplayer = new SudokuBoardDisplayer();

                Console.WriteLine("Enter the filename with sudoku puzzle");
                var filename = Console.ReadLine();

                var sudokuBoard = sudokuFileReader.ReadFile(filename);
                sudokuBoardDisplayer.Display("Intial State", sudokuBoard);

                bool isSolved = sudokuSolverEngine.Solve(sudokuBoard);
                sudokuBoardDisplayer.Display("Final State", sudokuBoard);

                Console.WriteLine(isSolved ? "You have solved Sudoku Puzzle!" : "Unfortunatley the program couldn't solved the puzzle");

                var cos = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}: {1}", "Sudoku Puzzle cannot be solved due to an error: ", e.Message);
            }
        }
    }
}
