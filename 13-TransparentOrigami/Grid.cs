using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _13_TransparentOrigami
{
    public class Grid
    {
        public List<Coord> Coords;
        public List<Fold> Folds;
        public int Height;
        public int Width;


        public Grid(string filename)
        {
            string[] lines = File.ReadAllLines(filename);

            Coords = new List<Coord>();
            Folds = new List<Fold>();

            int lineno = 0;
            while (lines[lineno].Trim().Length != 0)
            {
                var c = new Coord(lines[lineno++]);
                Coords.Add(c);
                if (c.X > Width) Width = c.X;
                if (c.Y > Height) Height = c.Y;
            }
            Height++;
            Width++;

            lineno++;
            while (lineno < lines.Length)
            {
                Folds.Add(new Fold(lines[lineno++]));
            }
        }

        public void Part2()
        {
            for (int i = 1; i < Folds.Count; i++)
            {
                FoldAndCount(Folds[i]);
            }
            bool[,] visualise = new bool[40, 6];
            foreach (var c in Coords)
            {
                visualise[c.X, c.Y] = true;
            }

            Console.WriteLine("Part 2 : \n");
            for (int Y = 0; Y < 6; Y++)
            {
                for (int X = 0; X < 40; X++)
                {
                    Console.Write(visualise[40-1-X, 6-1-Y] ? "#" :  " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
        public void Part1()
        {
            FoldAndCount(Folds[0]);

            Console.WriteLine($"Part 1 : {Coords.Count}");
        }

        private void FoldAndCount(Fold fold)
        {
            bool foldIsNearerToZero = (fold.FoldLine < ((fold.Horizontal ? Height : Width) + 1) / 2);

            foreach (var c in Coords)
            {
                if (fold.Horizontal)
                {
                    c.Y = Math.Abs(fold.FoldLine - c.Y) - 1;
                }
                else
                {
                    c.X = Math.Abs(fold.FoldLine - c.X) - 1;
                }
            }
            Coords = Coords.OrderBy(x => x.X * 10000 + x.Y).ToList();
            for (int i = Coords.Count - 1; i > 0; i--)
            {
                Coord curr = Coords[i];
                Coord prev = Coords[i - 1];
                if (curr.X == prev.X && curr.Y == prev.Y)
                    Coords.RemoveAt(i);
            }

        }
    }
}
