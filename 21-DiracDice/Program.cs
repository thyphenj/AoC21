using System;

namespace _21_DiracDice
{
    class Program
    {
        static void Main()
        {
            int[] playerPos = { 5, 10 };

            Part1(playerPos);
            Part2(playerPos);
        }

        static void Part1(int[] playerPos)
        {
            int[] playerScore = { 0, 0 };
            int rollno = 0;
            int playerNo = 0;

            while (playerScore[0] < 1000 && playerScore[1] < 1000)
            {
                rollno++;

                int die1 = (3 * rollno - 3) % 100 + 1;
                int die2 = (3 * rollno - 2) % 100 + 1;
                int die3 = (3 * rollno - 1) % 100 + 1;

                playerPos[playerNo] = (playerPos[playerNo] + die1 + die2 + die3 - 1) % 10 + 1;
                playerScore[playerNo] += playerPos[playerNo];
                //Console.WriteLine($"Player {playerNo + 1} rolls {die1,3}+{die2,3}+{die3,3} to space {playerPos[playerNo],2} for score of {playerScore[playerNo],4}");
                playerNo = 1 - playerNo;
            }
            Console.WriteLine($"Part 1 : {playerScore[playerNo] * 3 * rollno} ({playerScore[playerNo]} * {3 * rollno})");
        }

        static void Part2(int[] playerPos)
        {
            int[] playerScore = { 0, 0 };
            int rollno = 0;
            int playerNo = 0;

            long games = 444356092776315 + 341960390180808;

            Console.WriteLine($"Original {games}");
            while (games > 3)
            {
                Console.WriteLine($"{games / 3} {games % 3}");
                games /= 3;
            }
        }
    }
}
