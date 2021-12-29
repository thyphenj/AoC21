using System;
using System.IO;
using System.Collections.Generic;

namespace _15_Chiton
{
    public class Grid
    {
        public Cell[,] Cells;

        public int Height;
        public int Width;
        public int CurrX;
        public int CurrY;
        public int UnvisitedCount;

        public (int, int, long) CachedShortValue;

        public Grid(string filename, bool tiles = false)
        {
            string[] input = File.ReadAllLines(filename);
            Height = input.Length;
            Width = input[0].Length;

            if (tiles)
                Cells = new Cell[Height * 5, Width * 5];
            else
                Cells = new Cell[Height, Width];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Cells[x, y] = new Cell(int.Parse(input[y][x].ToString()));
                    if (tiles)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if (i != 0 || j != 0)
                                {
                                    int newX = i * Width + x;
                                    int newY = j * Height + y;
                                    Cells[newX, newY] = new Cell((Cells[x, y].Risk + i + j - 1) % 9 + 1);
                                }
                            }
                        }
                    }
                }
            }
            if (tiles)
            {
                Height *= 5;
                Width *= 5;
            }
            UnvisitedCount = Height * Width;

            GoAndSearch();
        }

        public void GoAndSearch()
        {
            CurrX = 0;
            CurrY = 0;

            Cells[CurrX, CurrY].ShortestPath = 0;

            List<(int, int)> shorties = new List<(int, int)>();

            while (UnvisitedCount > 0)
            {
                var currCell = Cells[CurrX, CurrY];

                // Look at unvisited neighbours

                if (CurrX > 0)
                    if (Cells[CurrX - 1, CurrY].UpdateRisk(currCell, CurrX, CurrY) != long.MaxValue)
                        shorties.Add((CurrX - 1, CurrY));

                if (CurrX + 1 < Width)
                    if (Cells[CurrX + 1, CurrY].UpdateRisk(currCell, CurrX, CurrY) != long.MaxValue)
                        shorties.Add((CurrX + 1, CurrY));

                if (CurrY > 0)
                    if (Cells[CurrX, CurrY - 1].UpdateRisk(currCell, CurrX, CurrY) != long.MaxValue)
                        shorties.Add((CurrX, CurrY - 1));

                if (CurrY + 1 < Height)
                    if (Cells[CurrX, CurrY + 1].UpdateRisk(currCell, CurrX, CurrY) != long.MaxValue)
                        shorties.Add((CurrX, CurrY + 1));

                // We're done with this one
                currCell.Unused = false;
                if (shorties.Contains((CurrX, CurrY)))
                    shorties.Remove((CurrX, CurrY));
                UnvisitedCount--;

                // Find next cell to make current
                (CurrX, CurrY) = FindShortestCell(shorties);

            }
            Console.WriteLine(Cells[Height - 1, Width - 1]);
        }

        public (int, int) FindShortestCell(List<(int, int)> shorties)
        {
            (int, int) shortest = (0, 0);
            long min = int.MaxValue;

            foreach (var s in shorties)
                if (Cells[s.Item1, s.Item2].ShortestPath < min)
                {
                    min = Cells[s.Item1, s.Item2].ShortestPath;
                    shortest = s;
                }

            return shortest;
        }

        public override string ToString()
        {
            string retval = "";
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    retval += Cells[x, y].Risk.ToString();
                }
                retval += "\n";
            }

            return retval;
        }
    }
}
