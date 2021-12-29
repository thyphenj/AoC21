using System;
using System.IO;
using System.Drawing;

namespace _15_Chiton
{
    class Program
    {
        static void Main()
        {
            string filename = "Input.txt";
            Grid grid = new Grid(filename);

            Grid grid2 = new Grid(filename, true);
        }
    }
}
