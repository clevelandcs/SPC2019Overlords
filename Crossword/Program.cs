using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = Console.ReadLine().Split(' ');
            int numWords = int.Parse(inputs[0]);
            int numRows = int.Parse(inputs[1]);
            int numCols = int.Parse(inputs[2]);
            List<string> words = new List<string>();
            char[,] crossword = new char[numRows, numCols];
            for(var i = 0; i < numRows; i++)
            {
                var row = Console.ReadLine();
               for(var j = 0; j < numCols; j++)
                {
                    crossword[i, j] = row[j];
                }
            }
            for(var i = 0; i < numWords; i++)
            {
                words.Add(Console.ReadLine());
            }
            var horizontalWords = GetWordsByDirection(crossword, numRows, numCols, numWords);
            var verticalWords = GetWordsByDirection(crossword, numCols, numRows, numWords);
            horizontalWords = horizontalWords.OrderByDescending(x => x.Length).ToList();
            verticalWords = verticalWords.OrderByDescending(x => x.Length).ToList();
            words = words.OrderByDescending(x => x.Length).ToList();
            
            WriteOutput(crossword, numRows, numCols);
        }
        private static bool IsBlank(char c)
        {
            return c == '#';
        }
        /**
         * Get horizontal words in a list following the format [x, y, length]
         * Get vertical words in a list following the format [y, x, length]
         */
        private static List<word> GetWordsByDirection(char[,] c, int rows, int cols, int wc)
        {
            List<word> words = new List<word>(wc * 3);
            for (int i = 0; i < rows; i++)
            {
                var wordLen = 0;
                for(int j = 0; j < cols; j++)
                {
                    var iStart = 0;
                    var jStart = 0;
                    if (IsBlank(c[i, j]))
                    {
                        if (wordLen == 0)
                        {
                            iStart = i;
                            jStart = j;
                        }
                        wordLen++;
                    }
                    else if (wordLen > 0)
                    {
                        words.Add(new word(iStart, jStart, wordLen));
                        wordLen = 0;
                    }
                }
            }
            return words;
        }

        private static void WriteOutput(char[,] c, int rows, int cols)
        {
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    Console.Write(c[i, j]);
                }
                Console.Write(System.Environment.NewLine);
            }
        }
    }
}

public class word
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Length { get; set; }

    public word(int x, int y, int len)
    {
        X = x;
        Y = y;
        Length = len;
    }
}