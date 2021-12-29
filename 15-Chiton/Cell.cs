using System;
using System.Collections.Generic;

namespace _15_Chiton
{
    public class Cell
    {
        public int Risk;
        public bool Unused;
        public long ShortestPath;
        public int CameFromX;
        public int CameFromY;

        public Cell(int risk)
        {
            Risk = risk;
            Unused = true;
            ShortestPath = long.MaxValue;
            CameFromX = 0;
            CameFromY = 0;
        }

        public void Update(long hop, int x, int y)
        {
            ShortestPath = hop;
            CameFromX = x;
            CameFromY = y;
        }

        public long UpdateRisk(Cell fromCell, int x, int y)
        {
            if (Unused)
            {
                long hop = fromCell.ShortestPath + Risk;
                if (hop < ShortestPath)
                {
                    Update(hop, x, y);
                    return hop;
                }
            }
            return long.MaxValue;
        }
        public override string ToString()
        {
            return $"d={ShortestPath} f=({CameFromX},{CameFromY})";
        }
    }
}
