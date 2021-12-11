using System;
using System.Collections.Generic;
using System.IO;

namespace _09_SmokeBasin
{
    public class Grid
    {
        public Cell[,] Input;
        public int LineLength;
        public int LineCount;
        public List<Cell> LowPoints = new List<Cell>();

        public Grid(string filename)
        {
            string[] allText = File.ReadAllLines(filename);

            //Size of array WITH border
            LineLength = allText[0].Length + 2;
            LineCount = allText.Length + 2;
            Input = new Cell[LineCount, LineLength];

            int x = 1;
            foreach (var line in allText)
            {
                int y = 0;

                foreach (var ch in $"9{line}9") // the 9s are border!!
                {
                    Input[x, y] = new Cell(x, y, int.Parse(ch.ToString()));
                    y++;
                }
                x++;
            }
            for (int y = 0; y < LineLength; y++)
            {
                Input[0, y] = new Cell(0, y, 9);
                Input[x, y] = new Cell(x, y, 9);
            }
        }

        public int AccumulateBasins()
        {
            int BasinNumber = 0;
            int BasinOffset = 10;
            foreach (var bas in LowPoints)
            {
                if (Input[bas.X - 1, bas.Y].Value < 9)
                    Input[bas.X - 1, bas.Y].Value = BasinNumber + BasinOffset;
                if (Input[bas.X + 1, bas.Y].Value < 9)
                    Input[bas.X + 1, bas.Y].Value = BasinNumber + BasinOffset;
                if (Input[bas.X, bas.Y - 1].Value < 9)
                    Input[bas.X, bas.Y - 1].Value = BasinNumber + BasinOffset;
                if (Input[bas.X, bas.Y + 1].Value < 9)
                    Input[bas.X, bas.Y + 1].Value = BasinNumber + BasinOffset;

                BasinNumber++;
            }
            int BasinCount = BasinNumber;

            while (MoreToProcess())
            {
                for (int i = 0; i < LineCount; i++)
                {
                    for (int j = 0; j < LineLength; j++)
                    {
                        Input[i, j].Value = NeighboursBasinNumber(i, j);
                    }
                }
            }
            int[] BasinSize = new int[BasinCount];

            for (int i = 0; i < LineCount; i++)
            {
                for (int j = 0; j < LineLength; j++)
                {
                    if (Input[i, j].Value > 9)
                        BasinSize[Input[i, j].Value - BasinOffset]++;
                }
            }
            Array.Sort(BasinSize);
            Array.Reverse(BasinSize);

            return BasinSize[0] * BasinSize[1] * BasinSize[2];
        }

        bool MoreToProcess()
        {
            for (int x = 0; x < LineCount; x++)
            {
                for (int y = 0; y < LineLength; y++)
                {
                    if (Input[x, y].Value < 9)
                        return true;
                }
            }
            return false;
        }

        int NeighboursBasinNumber(int x, int y)
        {
            if (Input[x, y].Value < 9)
            {
                if (Input[x - 1, y].Value > 9) return Input[x - 1, y].Value;
                if (Input[x + 1, y].Value > 9) return Input[x + 1, y].Value;
                if (Input[x, y - 1].Value > 9) return Input[x, y - 1].Value;
                if (Input[x, y + 1].Value > 9) return Input[x, y + 1].Value;
            }
            return Input[x, y].Value;
        }

        public int CountLowPoints()
        {
            int sum = 0;
            for (int i = 0; i < LineCount; i++)
            {
                for (int j = 0; j < LineLength; j++)
                {
                    if (LowerThanNeighbours(i, j))
                    {
                        int val = Input[i, j].Value;
                        sum += (val + 1);
                        LowPoints.Add(new Cell(i, j, val));
                    }
                }
            }
            return sum;


        }
        public bool LowerThanNeighbours(int x, int y)
        {
            if (y > 0 && Input[x, y].Value >= Input[x, y - 1].Value)
                return false;

            if (y < LineLength && Input[x, y].Value >= Input[x, y + 1].Value)
                return false;

            if (x > 0 && Input[x, y].Value >= Input[x - 1, y].Value)
                return false;

            if (x < LineCount && Input[x, y].Value >= Input[x + 1, y].Value)
                return false;

            return true; ;
        }

        public override string ToString()
        {
            string str = "";
            for (int x = 0; x < LineCount; x++)
            {
                for (int y = 0; y < LineLength; y++)
                {
                    int val = Input[x, y].Value;
                    if (val < 9)
                        str += val.ToString();
                    else if (val == 9)
                        str += "#";
                    else
                        str += (char)val;
                }
                str += "\n";
            }
            return str;
        }
    }
}
