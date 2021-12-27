using System;
namespace _15_Chiton
{
    public class Cell
    {
        public int Risk;
        public bool Unused;
        public int ShortPath;
        public int CameFromX;
        public int CameFromY;

        public Cell()
        {
        }

        public void Update( int hop, int x, int y)
        {
            ShortPath = hop;
            CameFromX = x;
            CameFromY = y;
        }

        public override string ToString()
        {
            return $"d={ShortPath} f={CameFromX} {CameFromY} {Unused}";
        }
    }
}
