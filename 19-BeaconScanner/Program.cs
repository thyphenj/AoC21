using System;

namespace _19_BeaconScanner
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "tinyinput.txt";

            var input = new RawData(filename);

            input.Part1();
            
        }
    }
}
