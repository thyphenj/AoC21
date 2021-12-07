using System;
namespace _04_GiantSquid
{
    public class Board
    {
        public int[] Cells { get; set; }
        public bool[] Matched { get; set; }
        public bool Completed { get; set; }

        public Board(string board)
        {
            Cells = new int[25];
            Matched = new bool[25];
            Completed = false;

            for (int i = 0; i < 25; i++)
            {
                Cells[i] = int.Parse(board.Substring(i * 3, 2));
                Matched[i] = false;
            }
        }

        public bool SetMatched(int number)
        {
            for (int i = 0; i < 25; i++)
            {
                if (Cells[i] == number)
                {
                    Matched[i] = true;
                    return CheckRow(i) || CheckCol(i);
                }
            }
            return false;
        }
        public void Draw()
        {
            string left = "";
            string rite = "";

            for (int i = 0; i < 25; i++)
            {
                if (Matched[i])
                {
                    left += "  X";
                }
                else
                {
                    left += "   ";
                }
                rite += $"{Cells[i],3}";
                if ((i + 1) % 5 == 0)
                {
                    Console.WriteLine($"{left}   {rite}");
                    left = "";
                    rite = "";
                }
            }
            Console.WriteLine();
        }

        private bool CheckRow(int index)
        {
            int from = 5*(index / 5);
            for (int i = from; i < from + 4; i++)
                if (!Matched[i])
                    return false;
            Console.WriteLine("ROW");
            return true;
        }
        private bool CheckCol(int index)
        {
            int col = index % 5;
            for (int i = col; i < 25; i+=5)
                if (!Matched[i])
                    return false;
            Console.WriteLine("COL");
            return true;
        }
    }
}
