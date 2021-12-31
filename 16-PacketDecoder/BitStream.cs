using System;

namespace _16_PacketDecoder
{
    public class BitStream
    {
        public uint[] Bits;
        public uint BitPtr;

        public BitStream(string input)
        {
            Bits = new uint[input.Length * 4];
            int i = 0;
            foreach (char ch in input)
            {
                uint digit = Convert.ToUInt16(ch.ToString(), 16);
                Bits[i++] = (digit >> 3) & 1;
                Bits[i++] = (digit >> 2) & 1;
                Bits[i++] = (digit >> 1) & 1;
                Bits[i++] = (digit >> 0) & 1;
            }
            BitPtr = 0;
        }

        public uint ReadBit()
        { 
            return Bits[BitPtr++];
        }

        public uint[] ReadBits(int count)
        {
            uint[] retval = new uint[count];
            for (int i = 0; i < count; i++)
                retval[i] = Bits[BitPtr++];
            return retval;
        }

        public ulong ReadValue(int count)
        {
            ulong retval = 0;

            foreach (var b in ReadBits(count))
            {
                retval = (retval * 2) + b;
            }
            return retval;
        }

        public ulong ReadLiteral()
        {
            ulong retval = 0;
            bool keepReading;
            do
            {
                keepReading = (ReadBit() == 1);
                retval = (retval * 16) + ReadValue(4);
            }
            while (keepReading);

            return retval;
        }
    }
}
