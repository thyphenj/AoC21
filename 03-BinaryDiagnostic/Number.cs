using System;
namespace _03_BinaryDiagnostic
{
    public class Number
    {
        public long Value { get; set; }
        public string ValueAsString { get; set; }
        public bool Removed { get; set; }

        public Number(string value)
        {
            ValueAsString = value;

            Value = 0;
            foreach (char s in value)
                Value = Value * 2 + (s == '0' ? 0 : 1);

            Removed = false;
        }
        public  override string ToString()
        {
            string rem = Removed ? "*****REMOVED*****" : "";
            return ($"{ValueAsString} ({Value,5} {rem})");
        }
    }

}
