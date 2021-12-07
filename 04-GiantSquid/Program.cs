using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04_GiantSquid
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new FileContents("input.txt");

            foreach (var num in input.Numbers)
            {
                Console.WriteLine($"--------------------> {num}");
                foreach (var brd in input.Boards.Where(x => !x.Completed))
                {
                    if (brd.SetMatched(num))
                    {
                        Console.WriteLine($"Score : {brd.Score(num)}");
                        brd.Completed = true;
                        brd.Draw();
                    }
                }
                if (input.CountUnsolved() == 0)
                    break;
            }
        }
    }
}
