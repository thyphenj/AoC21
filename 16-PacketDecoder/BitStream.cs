using System;
namespace _16_PacketDecoder
{
    public class BitStream
    {
        public uint[] Nibbles;
        public uint BitPtr;

        public uint VersionSum;

        public BitStream(string packet)
        {
            Nibbles = new uint[packet.Length];
            for (int i = 0; i < packet.Length; i++)
            {
                Nibbles[i] = Convert.ToUInt16(packet[i].ToString(), 16);
            }
            BitPtr = 0;
            VersionSum = 0;
        }
    }
}
