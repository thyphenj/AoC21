using System;
using System.IO;

namespace _24_ArithmeticLogicUnit
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input;
            input = new string[] { "inp z", "inp x", "mul z 3", "eql z x" };
            input = new string[]
                {
                    "inp w",
                    "add z w",
                    "mod z 2",
                    "div w 2",
                    "add y w",
                    "mod y 2",
                    "div w 2",
                    "add x w",
                    "mod x 2",
                    "div w 2",
                    "mod w 2"
            };

            input = new string[]
            {
                "inp w",
                "mul x 0",
                "add x z",
                "mod x 26",
                "div z 1",
                "add x 13",
                "eql x w",
                "eql x 0",
                "mul y 0",
                "add y 25",
                "mul y x",
                "add y 1",
                "mul z y",
                "mul y 0",
                "add y w",
                "add y 15",
                "mul y x",
                "add z y"
            };
            input = File.ReadAllLines("input.txt");

            long longNum = 18116121134117;
            string longStr = longNum.ToString();
            if (!longStr.Contains('0'))
            {
                var alu = new ALU(longNum);
                foreach (var str in input)
                {
                    alu.Process(str);
                }
                Console.WriteLine(alu);
            }
        }
    }
}
