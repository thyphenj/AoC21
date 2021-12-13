using System;
namespace _13_TransparentOrigami
{
    public class Coord
    {
        public int X;
        public int Y;

        public Coord(string line)
        {
            string[] tokens = line.Split(',');
            X = int.Parse(tokens[0]);
            Y = int.Parse(tokens[1]);
        }

        public override string ToString()
        {
            return $"{X,4},{Y,4}";
        }
    }
}
