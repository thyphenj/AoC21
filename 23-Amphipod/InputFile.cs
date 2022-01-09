using System;
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

        public int Part1
        {
            get
            {
                int retval = 0;

                var state = new State(RawInput);

                Console.WriteLine(state);
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
