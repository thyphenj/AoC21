using System;
using System.IO;
using System.Collections.Generic;

namespace _05_HydrothermalVenture
{
    class Program
    {
        static bool TEST = false;
        static int Size = 10;

        static int[,] Diagram;

        static List<LineSegment> Input = new List<LineSegment>();
        static void Main(string[] args)
        {
            // Read file
            foreach (string str in GetFile("input.txt"))
                Input.Add(new LineSegment(str));

            // --------------------------------------------------------------
            // -- Part 1 : Ignore diagonals
            // Create and populate Diagram

            Size = 1000;
            if (TEST)
                Size = 10;

            Diagram = new int[Size, Size];

            foreach (var line in Input)
            {
                if (line.Hor)
                {
                    for (int i = line.Fr.Y; i <= line.To.Y; i++)
                        Diagram[line.Fr.X, i]++;
                }
                if (line.Ver)
                {
                    for (int i = line.Fr.X; i <= line.To.X; i++)
                        Diagram[i, line.Fr.Y]++;
                }
            }

            //-- Count !
            int sum = 0;
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                {
                    if (Diagram[i, j] > 1)
                        sum++;
                }
            Console.WriteLine($"Part 1 : {sum}");
            Console.WriteLine();

            Draw();

            //-- Part 2 : include Diagonals
            foreach (var line in Input)
            {
                if (!line.Hor && !line.Ver)
                {
                    int x = line.Fr.X;
                    int y = line.Fr.Y;
                    int xInc = x > line.To.X ? -1 : +1;
                    int yInc = y > line.To.Y ? -1 : +1;
                    do
                    {
                        Diagram[x, y]++;
                        x += xInc;
                        y += yInc;
                    }
                    while (x != line.To.X); // X & Y should hit simultaneously!!!!
                    Diagram[x, y]++;
                }
            }
            //-- Count !
            sum = 0;
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                {
                    if (Diagram[i, j] > 1)
                        sum++;
                }
            Console.WriteLine($"Part 1 : {sum}");
            Console.WriteLine();

            Draw();
        }

        static void Draw()
        {
            if (TEST)
            {
                for (int y = 0; y < Size; y++)
                {
                    for (int x = 0; x < Size; x++)
                    {
                        string str = Diagram[x, y] == 0 ? "." : Diagram[x, y].ToString();
                        Console.Write(str);
                    }
                    Console.WriteLine();
                }
            }
        }

        static string[] GetFile(string filename)
        {
            if (TEST)
                return new string[]
                {
                "0,9 -> 5,9",
                "8,0 -> 0,8",
                "9,4 -> 3,4",
                "2,2 -> 2,1",
                "7,0 -> 7,4",
                "6,4 -> 2,0",
                "0,9 -> 2,9",
                "3,4 -> 1,4",
                "0,0 -> 8,8",
                "5,5 -> 8,2"
                };
            else
                return File.ReadAllLines(filename);
        }
    }
}
