using System;
using System.Collections.Generic;
using System.IO;

namespace _13_TransparentOrigami
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";

            Grid grid = new Grid(filename);

            grid.Part1();

            grid.Part2();

        }
    }
}
