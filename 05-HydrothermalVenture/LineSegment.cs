using System;
using System.Drawing;

namespace _05_HydrothermalVenture
{
    public class LineSegment
    {
        public Point Fr { get; set; }
        public Point To { get; set; }

        public bool Hor;
        public bool Ver;

        public LineSegment(string str)
        {
            string[] tokens = str.Split(" -> ");
            string[] work = tokens[0].Split(',');
            Fr = new Point(int.Parse(work[0]), int.Parse(work[1]));
            work = tokens[1].Split(',');
            To = new Point(int.Parse(work[0]), int.Parse(work[1]));

            Hor = Fr.X == To.X;
            Ver = Fr.Y == To.Y;

            if (Hor && Fr.Y > To.Y)
                Swap();
            if (Ver && Fr.X > To.X)
                Swap();
        }

        public override string ToString()
        {
            return $"[{Fr.X,3},{Fr.Y,3}]=>[{To.X,3},{To.Y,3}]";
        }

        private void Swap ()
        {
            Point Z = Fr;
            Fr = To;
            To = Z;
        }
    }
}
