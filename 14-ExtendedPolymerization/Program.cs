﻿using System;

namespace _14_ExtendedPolymerization
{
    class Program
    {
        static void Main()
        {
            string filename = "Input.txt";

            Input input = new Input(filename);

            input.Part1();

            input.Part2();
        }
    }
}
