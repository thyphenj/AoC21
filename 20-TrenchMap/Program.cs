using System;

namespace _20_TrenchMap
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "Input.txt";

            var map = new FileContents(filename);
//            map.Part1();

            map = new FileContents(filename);
            map.Part2();
        }
    }
}
