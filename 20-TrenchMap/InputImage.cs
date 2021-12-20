using System;
namespace _20_TrenchMap
{
    public class InputImage
    {
        public int[,] Map;
        public int Height;
        public int Width;
        public int Iterations;

        public bool ToggleBackground = false;
        public int Background = 0;
        public int Margin = 60;

        public ImageEnhancementAlgorithm IEA;

        public InputImage(string[] input)
        {
            IEA = new ImageEnhancementAlgorithm(input[0]);
            ToggleBackground = IEA.ValueAt(0) == 1 && IEA.ValueAt(511) == 0;

            Height = input.Length - 2;
            Width = input[2].Length;

            Map = new int[Height, Width];

            int lineNo = 2;
            while (lineNo < input.Length)
            {
                int i = lineNo - 2;
                for (int j = 0; j < Width; j++)
                {
                    Map[i, j] = input[lineNo][j] == '#' ? 1 : 0;
                }
                lineNo++;
            }
            Iterations = 0;
            AddMargin();
        }

        private void AddMargin()
        {
            int[,] newMap = new int[Height + 2 * Margin, Width + 2 * Margin];

            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    newMap[x + Margin, y + Margin] = Map[x, y];

            Map = newMap;

            Height += 2 * Margin;
            Width += 2 * Margin;
        }

        internal void Massage()
        {
            int[,] newMap = new int[Height, Width];

            for (int i = 1; i < Height - 1; i++)
            {
                for (int j = 1; j < Width - 1; j++)
                {
                    int pixelVal = IEA.ValueAt(NeighbourCode(i, j));
                    newMap[i, j] = pixelVal;
                }
            }
            Map = newMap;

            Iterations++;
            if (Iterations % 2 == 0)
                CleanMargin();
        }

        private void CleanMargin()
        {
            for (int i = 0; i < Height; i++)
            {
                Map[i, 1] = 0;
                Map[1, i] = 0;
            }
        }

        public int Count()
        {
            int retval = 0;
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                {
                    retval += Map[i, j];
                }

            return retval;
        }

        internal int NeighbourCode(int x, int y)
        {
            int val = 0;
            foreach (int i in new int[] { -1, 0, 1 })
                foreach (int j in new int[] { -1, 0, 1 })
                {
                    int xPos = x + i;
                    int yPos = y + j;

                    if (xPos >= 0 && xPos < Width && yPos >= 0 && yPos < Height)
                        val = (val * 2) + Map[xPos, yPos];
                }
            return val;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    str += Map[i, j] == 1 ? "#" : ".";
                }
                str += "\n";
            }
            return str + "\n";
        }
    }
}
