using System;
using System.Collections.Generic;
using System.IO;

namespace _04_GiantSquid
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Board> Boards = new List<Board>();
            List<int> Numbers = new List<int>();

            Console.WriteLine("Hello World");
        }

        private static (List<int>,List<Board>) ReadFile ( string filename)
        {
            List<Board> retBoards = new List<Board>();
            List<int> retNumbers = new List<int>();

            return (retNumbers, retBoards);
        }
    }
}
