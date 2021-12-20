using System;
using System.IO;

namespace _20_TrenchMap
{
    public class FileContents
    {
        public InputImage Map;

        public FileContents(string filename)
        {
            string[] input = File.ReadAllLines(filename);


            Map = new InputImage(input);
        }

        public void Part1()
        {

            Console.WriteLine(Map);

            Map.Massage();
            int count = Map.Count();
            Console.WriteLine(Map);
            Console.WriteLine($"Count = {count}\n");

            count = Map.Count();
            Console.WriteLine(Map);
            Console.WriteLine($"Count = {count}\n");
        }

        public void Part2 ()
        {
            int count=0;
            for (int i = 0; i < 50; i++)
            {
                Map.Massage();
                Console.WriteLine(Map);
            }
            count = Map.Count();

            Console.WriteLine(count);
        }
    }
}
