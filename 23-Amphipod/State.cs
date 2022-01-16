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

        private int _roomLen;
        private int _corrLen;

        public State(string[] input)
        {
            _corrLen = input[0].Length - 2;
            _roomLen = input.Length - 3;

            Corridor = new Cell[_corrLen];
            for (int i = 0; i < _corrLen; i++)
            {
                Corridor[i] = new Cell(i, input[1][i + 1]);
                Corridor[i].IsRestAllowed = !(i == 2 || i == 4 || i == 6 || i == 8);
            }
            Rooms = new Cell[4, _roomLen];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < _roomLen; j++)
                {
                    Rooms[i, j] = new Cell(input[j + 2][2 * i + 3], "ABCD"[i]);
                }
            }
        }

        public State(State state)
        {
            _roomLen = state._roomLen;
            _corrLen = state._corrLen;
            Corridor = new Cell[this._corrLen];
            Rooms = new Cell[4, _roomLen];

            Array.Copy(state.Corridor, Corridor, state.Corridor.Length);
            Array.Copy(state.Rooms, Rooms, state.Rooms.Length);
        }

        public List<State> PossibleMoves()
        {
            List<State> retval = new List<State>();

            foreach (var corrCell in Corridor)
            {
                if (corrCell.IsOccupied)
                {
                    var targetCell = Rooms[RoomIndex(corrCell.Value), 0];
                    if (targetCell.Value == corrCell.Value || !targetCell.IsOccupied)
                    {
                        if (IsRouteValid(corrCell))
                        {
                            retval.Add(Move(corrCell));
                        }
                    }
                }
            }

            return retval;
        }

        private State Move(Cell cor)
        {
            State retval = new State(this);

            int cost = 0;

            retval.Rooms[RoomIndex(cor.Value), 0].Value = cor.Value;
            retval.Corridor[cor.Position].Value = '.';

            return retval;
        }

        private bool IsRouteValid(Cell corrCell)
        {
            bool success = true;

            int from = corrCell.Position;
            int to = DoorIndex(corrCell.Value);
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

            // corridor
            str += "#";
            foreach (var ch in Corridor)
                str += ch.Value.ToString();
            str += "#\n";

            // Room line 0
            str += "###";
            for (int i = 0; i < 4; i++)
                str += $"{Rooms[i, 0].Value}#";
            str += "##\n";


            // subsequent room lines
            for (int j = 1; j < _roomLen; j++)
            {
                str += "  #";
                for (int i = 0; i < 4; i++)
                    str += $"{Rooms[i, j].Value}#";
                str += "\n";
            }
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
                str += $"{Rooms[i, 0].Value.ToString()}  ";
            str += "   ";

            // line 3
            for (int i = 0; i < 4; i++)
                str += $"{Rooms[i, 1].Value.ToString()}  ";

            return str;
        }
    }
}
