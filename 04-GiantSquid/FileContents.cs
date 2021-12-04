using System.IO;
using System.Collections.Generic;

namespace _04_GiantSquid
{
    public class FileContents
    {
        List<Board> Boards = new List<Board>();
        List<int> Numbers = new List<int>();

        public FileContents(string filename)
        {
            string[] contents = File.ReadAllLines(filename);

            string[] nums = contents[0].Split(',');
            foreach (string num in nums)
                Numbers.Add(int.Parse(num));

            int lineNo = 2; // zero based
            while (lineNo < contents.Length)
            {

            }
        }
    }
}
