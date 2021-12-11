using System;
using System.IO;

namespace _11_DumboOctopus
{
    public class Grid
    {
        public Cell[,] Input;
        public int Dimension;
        public int Flashes;

        public Grid(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            Dimension = lines[0].Length;
            Input = new Cell[Dimension, Dimension];
            for (int lineno = 0; lineno < Dimension; lineno++)
            {
                for (int charno = 0; charno < Dimension; charno++)
                {
                    Input[lineno, charno] = new Cell(int.Parse(lines[lineno][charno].ToString()));
                }
            }
            Flashes = 0;
        }

        public void IncrementIndividuals()
        {
            for (int lineno = 0; lineno < Dimension; lineno++)
            {
                for (int charno = 0; charno < Dimension; charno++)
                {
                    Input[lineno, charno].Increment();
                }
            }
        }

        public void FlashAndIncrementNeighbours()
        {
            int flashed;
            do
            {
                flashed = 0;
                for (int lineno = 0; lineno < Dimension; lineno++)
                {
                    for (int charno = 0; charno < Dimension; charno++)
                    {
                        if (Input[lineno, charno].FlashRequired)
                        {
                            flashed += Input[lineno, charno].Flash();

                            int xFr = Math.Max(lineno - 1, 0);
                            int yFr = Math.Max(charno - 1, 0);
                            int xTo = Math.Min(lineno + 1, Dimension - 1);
                            int yTo = Math.Min(charno + 1, Dimension - 1);

                            for (int i = xFr; i <= xTo; i++)
                            {
                                for (int j = yFr; j <= yTo; j++)
                                {
                                    if (!(i == lineno && j == charno))
                                        Input[i, j].Increment();
                                }
                            }
                        }
                    }
                }
            }
            while (flashed > 0);
        }

        public void AdjustFlashed()
        {
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    Flashes += Input[i, j].AdjustFlashed();
                }
            }
        }


        public override string ToString()
        {
            string retval = "";

            for (int lineno = 0; lineno < Dimension; lineno++)
            {
                for (int charno = 0; charno < Dimension; charno++)
                {
                    retval += $"{Input[lineno, charno].Value,2}";
                }
                retval += "\n";
            }
            retval += $"Flashes: {Flashes}\n\n";

            return retval;
        }
    }
}
