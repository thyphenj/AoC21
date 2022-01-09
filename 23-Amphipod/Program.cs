using System;

namespace _23_Amphipod
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "inCorridor.txt";

            InputFile input = new InputFile(filename);

            Console.WriteLine(input);
            Console.WriteLine();

            Console.WriteLine(input.Part1);

        }
    }
}
