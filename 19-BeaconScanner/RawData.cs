using System;
using System.Collections.Generic;
using System.IO;

namespace _19_BeaconScanner
{
    public class RawData
    {
        public List<Scanner> Scanners;

        public RawData(string filename)
        {
            Scanners = new List<Scanner>();
            string[] lines = File.ReadAllLines(filename);

            Scanner scanner;
            int lineNo = 0;
            while (lineNo < lines.Length)
            {
                scanner = new Scanner(lines[lineNo]);
                lineNo++;

                while (lineNo < lines.Length && lines[lineNo].Trim().Length > 0)
                {
                    scanner.Coords.Add(new Coord(lines[lineNo]));
                    lineNo++;
                }
                Scanners.Add(scanner);

                lineNo++;
            }
        }

        public void Part1()
        {
            Console.WriteLine("Original");
            foreach (var c in Scanners[0].Coords)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine();

            Console.WriteLine("X by 90");
            foreach (var c in Scanners[0].Coords)
            {
                c.RotateX();
                Console.WriteLine(c);
            }
            Console.WriteLine();

            Console.WriteLine("X by 180");
            foreach (var c in Scanners[0].Coords)
            {
                c.RotateX();
                Console.WriteLine(c);
            }
            Console.WriteLine();

            Console.WriteLine("X by 270");
            foreach (var c in Scanners[0].Coords)
            {
                c.RotateX();
                Console.WriteLine(c);
            }
            Console.WriteLine();

            Console.WriteLine("X by 360");
            foreach (var c in Scanners[0].Coords)
            {
                c.RotateX();
                Console.WriteLine(c);
            }
            Console.WriteLine();

        }
    }
}
