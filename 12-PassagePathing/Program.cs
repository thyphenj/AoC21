using System;

namespace _12_PassagePathing
{
    class Program
    {
        static void Main(string[] args)
        {
            String filename = "input.txt";

            CaveSystem caves = new CaveSystem(filename);
            caves.Part1();

            //caves = new CaveSystem(filename);
            caves.Part2();
        }
    }
}
