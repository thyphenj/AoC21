using System;
namespace _23_Amphipod
{
    public class Cell
    {
        public char Value;

        public bool IsRestAllowed;

        public bool IsOccupied => Value != '.';

        public bool IsRoom;

        public int Position;

        public Cell (int pos,char ch)
        {
            Value = ch;
            IsRoom = false;
            Position = pos;
        }
        public Cell(char ch, char roomName)
        {
            Value = ch;
            IsRoom = true;
        }
    }
}
