using System;
using System.IO;

namespace _16_PacketDecoder
{
    class Program
    {
        static void Main()
        {
            string str;

            str = File.ReadAllText("input.txt");

            //str = "D2FE28";
            //str = "38006F45291200";
            //str = "EE00D40C823060";
            //str = "8A004A801A8002F478";
            //str = "9C0141080250320F1802104A08";

            var p = new Packet(new BitStream(str));

            //Console.WriteLine(p.Stream.VersionSum);
            Console.WriteLine(p.Value);
        }
    }
}
