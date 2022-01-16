using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace _23_Amphipod
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class InputFile
    {
        string[] RawInput;

        public InputFile(string filename)
        {
            RawInput = File.ReadAllLines(filename);
        }

        public InputFile(string[] input)
        {
            RawInput = input;
        }

        public int Part1
        {
            get
            {
                int retval = 0;

                var state = new State(RawInput);

                var state2 = new State(state);
                

                List<State> moves = state.PossibleMoves();

                Console.WriteLine(state);
                Console.WriteLine(moves[0]);
                return retval;
            }
        }

        public override string ToString()
        {
            string str = "";
            foreach ( var line in RawInput)
            {
                str += (line + "\n");
            }
            return str;
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
