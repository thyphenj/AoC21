using System;

namespace _25_SeaCucumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid("Input.txt");

            int stepno = 0;
            int movements = 0;
            do
            {
                stepno++;

                movements = grid.CountMovesToEast();
                grid.MoveEast();
                movements += grid.CountMovesToSouth();
                grid.MoveSouth();

                if (movements == 0)
                {
                    Console.WriteLine($"After {stepno} step{(stepno == 1 ? ' ' : 's')}\n{grid}");
                }
            } while (movements > 0);
        }
    }
}
