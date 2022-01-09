using System;
using System.Collections.Generic;
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
                Corridor[i] = new Cell(i, input[1][i + 1]);
                Corridor[i].IsRestAllowed = !(i == 2 || i == 4 || i == 6 || i == 8);
            }
            Rooms = new Cell[4, 2];
            for (int i = 0; i < 4; i++)
            {
                Rooms[i, 1] = new Cell(input[2][2 * i + 3], "ABCD"[i]);
                Rooms[i, 0] = new Cell(input[3][2 * i + 3], "ABCD"[i]);
            }
        }

        public List<State> PossibleMoves()
        {
            List<State> retval = new List<State>();

            foreach (var cor in Corridor)
            {
                if (cor.IsOccupied)
                {
                    var targetCell = Rooms[RoomIndex(cor.Value), 0];
                    if (targetCell.Value == cor.Value || !targetCell.IsOccupied)
                    {
                        if (IsRouteValid(targetCell.Value, cor.Position))
                        {
                            int Cost = Move(cor);
                        }
                    }
                }
            }

            return retval;
        }

        private int Move(Cell cor)
        {
            int retval = 0;

            return retval;
        }
        private bool IsRouteValid(char targetRoom, int corridorPos)
        {
            bool success = true;

            int from = corridorPos;
            int to = DoorIndex(targetRoom);
            if (from > to)
            {
                int t = to;
                to = from;
                from = t;
            }
            for (int i = from + 1; i < to; i++)
            {
                success = false;
                if (Corridor[i].IsOccupied)
                    break;
                success = true;
            }
            return success;
        }
        private int RoomIndex(char ch)
        {
            return (int)(ch - 'A');
        }
        private int DoorIndex(char ch)
        {
            return ((int)(ch - 'A') + 1) * 2;
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
                str += $"{Rooms[i, 1].Value.ToString()}#";
            str += "##\n";

            // line 3
            str += "  #";
            for (int i = 0; i < 4; i++)
                str += $"{Rooms[i, 0].Value.ToString()}#";
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
