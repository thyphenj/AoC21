using System;

namespace _16_PacketDecoder
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new Packet("D2FE28");

            foreach (var ch in x.Nibble)
                Console.Write(ch + " ");
            Console.WriteLine();
        }
    }
}
