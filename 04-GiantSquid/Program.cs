using System;
using System.Collections.Generic;
using System.IO;

namespace _04_GiantSquid
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new FileContents("input.txt");

            foreach ( var num in input.Numbers)
            {
                Console.WriteLine($"--------------------{num}");
                foreach ( var brd in input.Boards)
                {
                    if (!brd.Completed)
                    {
                        if (brd.SetMatched(num))
                        {
                            brd.Completed = true;
                            int score = CalculateScore(brd, num);
                            Console.WriteLine($"Part 1 : {score} ({num})");
                        }
                        brd.Draw();
                    }
                }

                if (input.CountUnsolved() == 0)
                    break;
            }
        }
        static int CalculateScore ( Board brd, int num)
        {
            int sum = 0;
            for (int i = 0; i < 25; i++)
            {
                if (!brd.Matched[i])
                    sum += brd.Cells[i];
            }
            return sum * num;
        }
    }
}
