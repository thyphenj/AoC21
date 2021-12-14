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
        public int RouteCount;
        public Stack<string> Route = new Stack<string>();
        public int SmallVisitCount;

        public CaveSystem(string filename)
        {
            Caves = new List<Cave>();

            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
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

            Caves = Caves.OrderBy(x => x.Name).ToList();
            foreach (var c in Caves)
                c.Neighbours = c.Neighbours.OrderBy(x => x.Name).ToList();

            RouteCount = 0;
        }

        public void Part1()
        {
            RouteCount = 0;

            Traverse_ONE(Start);
            Console.WriteLine();

            Console.WriteLine($"Part 1 : {RouteCount}");
        }

        public void Part2()
        {
            RouteCount = 0;

            Travers_TWO(Start);
            Console.WriteLine();

            Console.WriteLine($"Part 2 : {RouteCount}");
        }

        public void Traverse_ONE(Cave currentCave)
        {
            Route.Push(currentCave.Name);
            if (currentCave.Name == "end")
            {
                OutputStack();
                RouteCount++;
            }
            else
            {
                if (currentCave.Big || !currentCave.Visited)
                {
                    currentCave.Visit();

                    foreach (var cave in currentCave.Neighbours)
                        Traverse_ONE(cave);

                    currentCave.ResetVisit();
                }
            }
            Route.Pop();
        }

        public void Travers_TWO(Cave currentCave)
        {
            Route.Push(currentCave.Name);
            if (currentCave.Name == "end")
            {
                OutputStack();
                RouteCount++;
            }
            else
            {
                if (currentCave.Big || !currentCave.Visited )
                {
                    currentCave.Visit();

                    foreach (var cave in currentCave.Neighbours)
                        if (cave.Name != "start")
                            Travers_TWO(cave);

                    currentCave.ResetVisit();
                }
            }
            Route.Pop();
        }

        private void OutputStack()
        {
            string str = "";
            foreach (var s in Route)
            {
                str = $"{s}  " + str;
            }
            Console.WriteLine(str);
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
