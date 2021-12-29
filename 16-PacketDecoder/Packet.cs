using System;
namespace _16_PacketDecoder
{
    public class Packet
    {
        public string RawPacket;

        public BitStream Stream;

        public uint Version;
        public uint TypeId;

        public static int Depth;

        public Packet(BitStream stream)
        {
            Stream = stream;
            DecodePacket();
        }

        public void DecodePacket()
        {
            Depth++;

            Version = GetBitsAsUint(3);
            TypeId = GetBitsAsUint(3);
            Stream.VersionSum += Version;

            if (TypeId == 4)    //literal value
            {
                ulong literal = 0;
                bool literalIncomplete = true;
                do
                {
                    literalIncomplete = (GetOneBit() == 1);
                    literal = literal * 16 + GetBitsAsUint(4);
                }
                while (literalIncomplete);

                for (int i = 0; i < Depth; i++)
                    Console.Write("  ");
                Console.WriteLine($"Version {Version} type {TypeId} literal {literal}");

            }
            else                // operator
            {
                if (GetOneBit() == 0)
                {
                    uint subLength = GetBitsAsUint(15);
                    uint targetBit = (uint)(Stream.BitPtr + subLength);

                    for (int i = 0; i < Depth; i++)
                        Console.Write("  ");
                    Console.WriteLine($"Version {Version} type {TypeId} Contains {subLength} bits");
                    do
                    {
                        var p = new Packet(Stream);
                    } while (Stream.BitPtr < targetBit);
                }
                else
                {
                    uint numPackets = GetBitsAsUint(11);
                    for (int i = 0; i < Depth; i++)
                        Console.Write("  ");
                    Console.WriteLine($"Version {Version} type {TypeId} Contains {numPackets} packets");
                    for (int i = 0; i < numPackets; i++)
                    {
                        var p = new Packet(Stream);
                    }
                }
            }
            Depth--;
        }

        private uint GetOneBit()
        {
            uint currNibble = GetNibbleAt(Stream.BitPtr);
            uint currBit = GetBitAt(currNibble, Stream.BitPtr);

            Stream.BitPtr++;
            return currBit;
        }

        private uint GetBitsAsUint(int count)
        {
            uint retval = 0;

            for (int i = 0; i < count; i++)
            {
                uint currNibble = GetNibbleAt(Stream.BitPtr);
                uint currBit = GetBitAt(currNibble, Stream.BitPtr);
                retval = retval * 2 + currBit;
                Stream.BitPtr++;
            }

            return retval;
        }

        private uint GetNibbleAt(uint ptr)
        {
            return Stream.Nibbles[ptr / 4];
        }

        private uint GetBitAt(uint nibble, uint ptr)
        {
            uint mask = (ptr % 4) switch
            {
                0 => 8,
                1 => 4,
                2 => 2,
                3 => 1,
                _ => 0
            };
            return (uint)((nibble & mask) > 0 ? 1 : 0);
        }
    }
}
