using System;
using System.Collections.Generic;
using System.IO;

namespace _22_ReactorReboot
{
    public class InputFile
    {
        public List<Hexahedron> Hexas;

        public InputFile(string filename)
        {
            Hexas = new List<Hexahedron>();

            foreach (var line in File.ReadAllLines(filename))
            {
                Hexas.Add(new Hexahedron(line));
            }
        }

        public int Part1
        {
            get
            {
                bool[,,] ipa = new bool[101, 101, 101];
                int totalOn = 0;

                foreach (var line in Hexas)
                {
                    if (line.InsideIPA)
                    {
                        for (int x = Math.Max(line.X[0],-50); x <= Math.Min(line.X[1],50); x++)
                        {
                            for (int y = Math.Max(line.Y[0], -50); y <= Math.Min(line.Y[1], 50) ; y++)
                            {
                                for (int z = Math.Max(line.Z[0],-50); z <= Math.Min(line.Z[1], 50) ; z++)
                                {
                                    if (ipa[x + 50, y + 50, z + 50] != line.TurnOn)
                                    {
                                        ipa[x + 50, y + 50, z + 50] = line.TurnOn;
                                        totalOn += (line.TurnOn ? 1 : -1);
                                    }
                                }
                            }
                        }
                    }
                }
                return totalOn;
            }
        }

        public long Part2
        {
            get
            {
                long total = 0;

                return total;
            }
        }
    }
}
