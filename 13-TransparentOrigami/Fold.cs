using System;
namespace _13_TransparentOrigami
{
    public class Fold
    {
        public int FoldLine;
        public bool Horizontal;

        public Fold(string line)
        {
            // fold along x=655

            string[] tokens = line.Split('=');
            Horizontal = tokens[0][11] == 'y';
            FoldLine = int.Parse(tokens[1]);
        }

        public override string ToString()
        {
            return "fold" + (Horizontal?" Hor ":" Ver ") + FoldLine.ToString();
        }
    }
}
