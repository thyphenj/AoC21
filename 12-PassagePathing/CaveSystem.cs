using System;
using System.IO;
using System.Collections.Generic;

namespace _12_PassagePathing
{
    public class CaveSystem
    {
        public List<Cave> Caves;

        public CaveSystem(string filename)
        {
            Caves = new List<Cave>();

            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines )
            {
                string[] tokens = line.Split('-');
                var cave1 = new Cave(tokens[0]);
                var cave2 = new Cave(tokens[1]);

                if (Caves.Exists(x => x.Name == cave1.Name))
                    cave1 = Caves.Find(x => x.Name == cave1.Name);
                else
                    Caves.Add(cave1);

                if (Caves.Exists(x => x.Name == cave2.Name))
                    cave2 = Caves.Find(x => x.Name == cave2.Name);
                else
                    Caves.Add(cave2);

                cave1.AddNeighbour(cave2);
                cave2.AddNeighbour(cave1);
            }
            Console.WriteLine(WriteCaves());
        }

        public void Part1()
        {

        }
        public void Part2 ()
        {

        }
        public string WriteCaves()
        {
            string str = "";
            foreach (var cave in Caves)
                str += cave.ToString() + "\n";
            return str;
        }
    }
}
