using System;
using System.Diagnostics;

namespace _23_Amphipod
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class State
    {
        public Cell[] Corridor;
        public Cell[,] Rooms;

        public State(string[] input)
        {
            Corridor = new Cell[11];
            for (int i = 0; i < 11; i++)
            {
                Corridor[i] = new Cell(input[1][i + 1]);
                Corridor[i].IsRestAllowed = !(i == 2 || i == 4 || i == 6 || i == 8);
            }
            Rooms = new Cell[4, 2];
            for (int i = 0; i < 4; i++)
            {
                Rooms[i, 1] = new Cell(input[2][2 * i + 3], "ABCD"[i]);
                Rooms[i, 0] = new Cell(input[3][2 * i + 3], "ABCD"[i]);
            }
        }

        public override string ToString()
        {
            // line 0
            string str = "#############\n";

            // line 1
            str += "#";
            foreach (var ch in Corridor)
                str += ch.Value.ToString();
            str += "#\n";

            // line 2
            str += "###";
            for (int i = 0; i < 4; i++)
                str += $"{Rooms[i,1].Value.ToString()}#";
            str += "##\n";

            // line 3
            str += "  #";
            for (int i = 0; i < 4; i++)
                str += $"{Rooms[i,0].Value.ToString()}#";
            str += "\n";

            // line 4
            str += "  #########";

            return str;
        }

        private string GetDebuggerDisplay()
        {
            string str = "";

            // line 1
            foreach (var ch in Corridor)
                str += ch.Value.ToString();
            str += "      ";

            // line 2
            for (int i = 0; i < 4; i++)
                str += $"{Rooms[i, 1].Value.ToString()}  ";
            str += "   ";

            // line 3
            for (int i = 0; i < 4; i++)
                str += $"{Rooms[i, 0].Value.ToString()}  ";

            return str;
        }
    }
}
