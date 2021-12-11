namespace _09_SmokeBasin
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }

        public Cell(int x, int y, int value)
        {
            X = x;
            Y = y;
            Value = value;
        }

        public override string ToString()
        {
            return $"[{X,2},{Y,2}] - {Value}"; 
        }
    }
}