using System;
using System.IO;

namespace _25_SeaCucumber
{
    public class Grid
    {
        public CellState[,] Cells;
        public int Height, Width;

        public bool[,] CanMove;

        public Grid(string filename)
        {
            string[] input = File.ReadAllLines(filename);
            Height = input.Length;
            Width = input[0].Length;

            Cells = new CellState[Height, Width];
            CanMove = new bool[Height, Width];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Cells[i, j] = input[i][j] switch
                    {
                        'v' => CellState.Down,
                        '>' => CellState.Rite,
                        _ => CellState.Empty,
                    };
                }
            }
        }

        public int CountMovesToEast()
        {
            int retval = 0;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    CanMove[i, j] = Cells[i, j] == CellState.Rite
                        && Cells[i, (j + 1) % Width] == CellState.Empty;
                    if (CanMove[i, j])
                        retval++;
                }
            }
            return retval;
        }

        public void MoveEast()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (CanMove[i, j])
                    {
                        Cells[i, j] = CellState.Empty;
                        Cells[i, (j + 1) % Width] = CellState.Rite;
                        CanMove[i, j] = false;
                    }
                }
            }
        }

        public int CountMovesToSouth()
        {
            int retval = 0;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    CanMove[i, j] = Cells[i, j] == CellState.Down
                        && Cells[(i+1)%Height, j] == CellState.Empty;
                    if (CanMove[i, j])
                        retval++;
                }
            }
            return retval;
        }

        public void MoveSouth()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (CanMove[i, j])
                    {
                        Cells[i, j] = CellState.Empty;
                        Cells[(i+1)%Height, j] = CellState.Down;
                        CanMove[i, j] = false;
                    }
                }
            }
        }

        public string Sizeof()
        {
            return $"HxW {Height} x {Width}";
        }

        public override string ToString()
        {
            string str = "";

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    str += Cells[i, j]
                        switch
                    {
                        CellState.Down => "v",
                        CellState.Rite => ">",
                        _ => ".",
                    };
                }
                str += "\n";
            }
            return str;
        }
    }
}
