using System;

namespace _23_Amphipod
{
    class Program
    {
        static void Main(string[] args)
        {
            //string filename = "input.txt";
            //InputFile input = new InputFile(filename);

            string[] testInput =
                {
                    "#############",
                    "#.A.........#",
                    "###.#C#B#D###",
                    "  #A#D#C#B#",
                    "  #########"
                };
            InputFile input = new InputFile(testInput);

            Console.WriteLine(input.Part1);

        }
    }
}
