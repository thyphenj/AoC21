using System;
using System.Collections.Generic;

namespace _09_SmokeBasin
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid("input.txt");

            //----------------------------------------------------
            //-- Part 1 :

            Console.WriteLine($"Part 1 : {grid.CountLowPoints()}");

            //----------------------------------------------------
            //-- Part 2 :

            Console.WriteLine($"Part 2 : {grid.AccumulateBasins()}");
        }
    }
}
