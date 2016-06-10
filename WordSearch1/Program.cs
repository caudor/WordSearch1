using System;

namespace WordSearch1
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildPuzzle();
        }

        public static void BuildPuzzle()
        {
            Puzzle myPuzzle = new Puzzle();
            myPuzzle.SetPuzzleSize(15);
            myPuzzle.SetTheme("Names of People");
            myPuzzle.InitGrid();
            myPuzzle.CreateWordList();
            var result = myPuzzle.PlaceWords();
            myPuzzle.FillGrid();
            
            Console.WriteLine();
            Console.WriteLine("Puzzle size is " + myPuzzle.Size);
            Console.WriteLine("Puzzle theme is " + myPuzzle.Theme);
            Console.WriteLine("Solution:");
            Console.WriteLine(myPuzzle.Solution);
            Console.WriteLine(myPuzzle.PrintString);
            myPuzzle.ShowGrid();
            myPuzzle.SaveFormattedGrid();
            //Console.WriteLine("The Formatted Grid: ");
            //For printing to paper
            //Console.Write(myPuzzle.FormattedPrintString);
            if (result)
                Console.WriteLine("Operation Complete");
        }
    }
}
