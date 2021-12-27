using System;
using System.IO;
using System.Drawing;

namespace _15_Chiton
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "testInput.txt";
            string[] input = File.ReadAllLines(filename);
            int Height = input.Length;
            int Width = input[0].Length;

            Cell[,] Cells = new Cell[Height, Width];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Cell c = new Cell()
                    {
                        Risk = int.Parse(input[y][x].ToString()),
                        Unused = true,
                        ShortPath = int.MaxValue,
                        CameFromX = 0,
                        CameFromY = 0
                    };
                    Cells[x, y] = c;
                }
            }

            Cells[0, 0].ShortPath = 0;
            while ( FindShortestPath())
            { }
            for (int X = 0; X < Width; X++)
            {
                for (int Y = 0; Y < Height; Y++)
                {
                    var currCell = Cells[X, Y];

                    // Look at unvisited neighbours
                    // 0-up : 1-down : 2-left : 3-rite
                    int offset = X - 1;
                    if (X > 0 && Cells[offset, Y].Unused)
                    {
                        int hop = currCell.ShortPath + Cells[offset, Y].Risk;
                        if (hop < Cells[X, Y].ShortPath)
                        {
                            Cells[offset, Y].Update(hop, X, Y);
                        }
                    }
                    offset = X + 1;
                    if (X < Width - 1 && Cells[offset, Y].Unused)
                    {
                        int hop = currCell.ShortPath + Cells[offset, Y].Risk;
                        if (hop < Cells[offset, Y].ShortPath)
                        {
                            Cells[offset, Y].Update(hop, X, Y);
                        }
                    }
                    offset = Y - 1;
                    if (Y > 0 && Cells[X, offset].Unused)
                    {
                        int hop = Cells[X, Y].ShortPath + Cells[X, offset].Risk;
                        if (hop < Cells[X, offset].ShortPath)
                        {
                            Cells[X, offset].Update(hop, X, Y);
                        }
                    }
                    offset = Y + 1;
                    if (Y < Height - 1 && Cells[X, offset].Unused)
                    {
                        int hop = Cells[X, Y].ShortPath + Cells[X, offset].Risk;
                        if (hop < Cells[X, offset].ShortPath)
                        {
                            Cells[X, offset].Update(hop, X, Y);
                        }
                    }
                    Cells[X, Y].Unused = false;
                }
            }
            Console.WriteLine(Cells[Height - 1, Width - 1]);
        }

        public bool FindShortestPath()
        {
            return false;
        }
    }
}
