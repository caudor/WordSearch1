using System;
using System.Collections.Generic;
using System.Text;

namespace WordSearch1
{
    public class Puzzle
    {
        public int Size { get; private set; }
        public string Theme { get; private set; }
        public bool AllWordsSet { get; private set; }
        public string Solution { get; private set; }
        public string PrintString { get; private set; }
        public string FormattedPrintString { get; private set; }

        private List<string> wordlist = new List<string>();  //init list
        private char[,] _grid;

        public Puzzle()
        {
            Size = 25;
            Theme = "Word Search Puzzle";
            //AllWordsSet = false;
            Solution = "No Solution";
        }

        public void InitGrid()
        {   
            _grid = new char[Size, Size];
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    _grid[i, j] = ' ';
                }
            }
        }

        public void CreateWordList()
        {
            var list1 = new WordList();
            wordlist = list1.Getwords();
        }

        public void SetPuzzleSize(int size)
        {
            Size = size;
        }

        public void SetTheme(string theme)
        {
            Theme = theme;
        }

        public bool PlaceWords()
        {
            var random = new Random();
            var flag = true;
            StringBuilder sb = new StringBuilder();
            var placedCount = 0;
            
            while (!AllWordsSet)
            {
                while (placedCount < wordlist.Count)    //need to keep going until the word is placed
                {
                    int randomNumber = random.Next(1, 9);

                    //Console.WriteLine(randomNumber);
                    //Set placement contraints based on wordsize here
                    int wordSize = wordlist[placedCount].Length;
                    int conRow = wordSize - 1;
                    int conCol = Size - wordSize;
                    int cellX = random.Next(conRow, conCol);
                    int cellY = random.Next(conRow, conCol);
                    //Check if word can be placed and set flag
                    flag = true;

                    var watchWord = wordlist[placedCount];

                    for (var i = 0; i < wordSize; i++)
                    {
                        var myTuple = GetSteps(randomNumber, i);
                        //Console.WriteLine("myTuple is: " + myTuple);
                        var myX = myTuple.Item1;
                        var myY = myTuple.Item2;
                        if (_grid[cellX + myX, cellY + myY] != ' ' && _grid[cellX + myX, cellY + myY] != watchWord[i])
                            flag = false;
                    }

                    if (flag)
                    {
                        var logx = 0;
                        var logy = 0;
                        var tempWord = wordlist[placedCount];
                        for (var x = 0; x < wordSize; x++)
                        {
                            var myTuple1 = GetSteps(randomNumber, x);
                            //Console.WriteLine("myTuple is: " + myTuple);
                            var myX = myTuple1.Item1;
                            var myY = myTuple1.Item2;

                            _grid[cellX + myX, cellY + myY] = tempWord[x];
                            logx = cellX + myX;
                            logy = cellY + myY;

                            if ( x == 0)
                            {
                                sb.Append(tempWord);
                                sb.Append(",");
                                sb.Append(randomNumber);
                                sb.Append(",");
                                sb.Append(logx);
                                sb.Append(",");
                                sb.Append(logy);
                                sb.Append(",");
                            }

                        }  //end for
                        Solution = sb.ToString();
                        placedCount++;
                    }  //end of for

                    AllWordsSet = true;
                }  // end of while

            } //end of while
            return true;
        }

        public void ShowGrid()
        {
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    Console.Write(_grid[i, j] + " ");
                    
                    if (j / (Size - 1) == 1)
                        Console.Write("\n");
                }
            }
        }

        public void FillGrid()
        {
            StringBuilder gb = new StringBuilder();
            var myrandom = new Random();
            
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    if (_grid[i, j] == ' ')
                    {
                        int t = myrandom.Next(65, 91);
                        _grid[i, j] = (char)t;
                    }
                    gb.Append(_grid[i, j]);
                }
            }
            PrintString = gb.ToString();
        }

        public void SaveFormattedGrid()
        {
            StringBuilder gb = new StringBuilder();
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    gb.Append(_grid[i, j] + " ");

                    if (j / (Size - 1) == 1)
                        gb.Append("\n");
                }
            }

            foreach (var word in wordlist)
            {
                gb.Append("\n" +word);
            }
            FormattedPrintString = gb.ToString();
            // You do NOT need to call Flush() or Close().
            System.IO.File.WriteAllText(@"C:\Users\Chris\Documents\PuzzlePrint.txt", FormattedPrintString);
        }

        public Tuple<int,int> GetSteps(int randomNumber, int i)
        {
            int x = 0;
            int y = 0;
            int _randomNumber = randomNumber;

            switch (randomNumber)
            {
                case 1:
                    x = 0;
                    y = i;
                    break;
                case 2:
                    x = i;
                    y = 0;
                    break;
                case 3:
                    x = i;
                    y = 1;
                    break;
                case 4:
                    x = i;
                    y = -i;
                    break;
                case 5:
                    x = 0;
                    y = -i;
                    break;
                case 6:
                    x = -i;
                    y = 0;
                    break;
                case 7:
                    x = -i;
                    y = -i;
                    break;
                case 8:
                    x = -1;
                    y = i;
                    break;
            }
            return Tuple.Create(x, y);
        }
    }
}    

