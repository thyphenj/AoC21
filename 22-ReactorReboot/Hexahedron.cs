using System;
namespace _22_ReactorReboot
{
    public class Hexahedron
    {
        public bool TurnOn;
        public int[] X;
        public int[] Y;
        public int[] Z;

        public bool InsideIPA;

        public Hexahedron(string line)
        {
            string[] coords;

            TurnOn = (line[1] == 'n');

            if (TurnOn)
                coords = line.Substring(3).Split(',');
            else
                coords = line.Substring(4).Split(',');

            X = GetRange(coords[0]);
            Y = GetRange(coords[1]);
            Z = GetRange(coords[2]);

            InsideIPA = IsItInIPA(X) && IsItInIPA(X) && IsItInIPA(Z);
        }

        public long Size()
        {
            return (X[1] - X[0]) * (Y[1] - Y[0]) * (Z[1] - Z[0]);
        }

        private int[] GetRange ( string str)
        {
            string[] vals = str.Substring(2).Split("..");
            return new int[] { int.Parse(vals[0]), int.Parse(vals[1]) };
        }

        private bool IsItInIPA (int[] i)
        {
            return (i[0] >= -50 && i[0] <= 50 && i[1] >= -50 && i[1] <= 50);
        }

        public override string ToString()
        {
            return (InsideIPA ? "INS " : "    ")
                + (TurnOn ? "on " : "off")
                + $" {X[0]}..{X[1]},{Y[0]}..{Y[1]},{Z[0]}..{Z[1]}        "
                + $"{Size()}";
        }
    }
}
