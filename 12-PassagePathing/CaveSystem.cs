using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _12_PassagePathing
{
    public class CaveSystem
    {
        public List<Cave> Caves;
        public Cave Start;
        public Cave End;

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

                if (Start == null && cave1.Name == "start") Start = cave1;
                if (Start == null && cave2.Name == "start") Start = cave2;

                if (End == null && cave1.Name == "end") End = cave1;
                if (End == null && cave2.Name == "end") End = cave2;
            }
        }

        public void Part1()
        {
            List<Cave> removed = new List<Cave>();

            Console.WriteLine($"FROM [{Start.ToString()} TO [{End.ToString()}]");
            Console.WriteLine();

            Console.WriteLine(WriteCaves());
            //Remove isolated "small" caves

            for (int i = Caves.Count - 1; i >= 0; i--)
            {
                var cave = Caves[i];
                if (!cave.Big && cave.Neighbours.Count == 1 && !cave.Neighbours[0].Big)
                {
                    Caves.RemoveAt(i);
                }
            }
       

            Console.WriteLine(WriteCaves());
            Console.WriteLine();

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
