using System;
using System.IO;
using System.Collections.Generic;

namespace _11_DumboOctopus
{
    class Program
    {
        static int Dimension = 10;
        static Cell[,] input;
        static Grid grid;

        static void Main(string[] args)
        {
            grid = new Grid("Input.txt");

            Part1();
        }

        static void Part1()
        {
            for (int i = 0; i < 100; i++)
            {
                grid.IncrementIndividuals();

                grid.FlashAndIncrementNeighbours();

                grid.AdjustFlashed();
            }
            Console.WriteLine(grid.Flashes);
        }


        static string PrintGrid()
        {
            string retval = "";
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    retval += $"{input[i, j].Value,3}";
                }
                retval += "\n";
            }
            retval += "\n";

            return retval;
        }
    }
}