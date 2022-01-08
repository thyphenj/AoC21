using System;

namespace _22_ReactorReboot
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";

            var input = new InputFile(filename);

            Console.WriteLine($"Part 1 : {input.Part1}");

            Console.WriteLine($"Part 2 : {input.Part2}");
        }
    }
}
