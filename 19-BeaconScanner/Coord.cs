namespace _19_BeaconScanner
{
    public class Coord
    {
        public int X;
        public int Y;
        public int Z;

        public Coord(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Coord(string str)
        {
            string[] tokens = str.Split(',');

            X = int.Parse(tokens[0]);
            Y = int.Parse(tokens[1]);
            Z = int.Parse(tokens[2]);
        }

        public override string ToString()
        {
            return $"[{X,4} {Y,4} {Z,4}]";
        }

        public void RotateX()
        {
            Rotate (new int[,]
            {
                {  1,  0,  0 },
                {  0,  0, -1 },
                {  0,  1,  0 }
            });
        }
        public void RotateY()
        {
            Rotate( new int[,]
            {
                {  0,  0,  1 },
                {  0,  1,  0 },
                { -1,  0,  0 }
            });
        }
        public void RotateZ()
        {
            Rotate ( new int[,]
            {
                {  0, -1,  0 },
                {  1,  0,  0 },
                {  0,  0,  1 }
            });
        }

        public void  Rotate(int[,] matrix)
        {
            int x = X * matrix[0, 0] + Y * matrix[0, 1] + Z * matrix[0, 2];
            int y = X * matrix[1, 0] + Y * matrix[1, 1] + Z * matrix[1, 2];
            int z = X * matrix[2, 0] + Y * matrix[2, 1] + Z * matrix[2, 2];

            X = x;
            Y = y;
            Z = z;
        }
    }
}