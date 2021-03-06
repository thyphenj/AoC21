using System.IO;
using System.Collections.Generic;

namespace _04_GiantSquid
{
    public class FileContents
    {
        public List<int> Numbers = new List<int>();
        public List<Board> Boards = new List<Board>();

        public FileContents(string filename)
        {
            string[] contents = File.ReadAllLines(filename);

            //-- Numbers on line[0]
            foreach (string num in contents[0].Split(','))
                Numbers.Add(int.Parse(num));


            int lineNo = 2; // zero based
            while (lineNo < contents.Length)
            {
                Boards.Add(new Board($"{contents[lineNo]} {contents[lineNo + 1]} {contents[lineNo + 2]} {contents[lineNo + 3]} {contents[lineNo + 4]}"));
                lineNo+=6;
            }
        }

        public int CountUnsolved ()
        {
            int solved = 0;
            foreach ( var b in Boards)
            {
                if (b.Completed)
                    solved++;
            }
            return Boards.Count - solved;
        }
    }
}
