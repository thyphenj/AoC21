using System;
namespace _16_PacketDecoder
{
    public class Packet
    {
        public string RawPacket;

        public int[] Nibble;

        public int Version;
        public int TypeId;

        public int PktPtr;

        public Packet(string packet)
        {
            RawPacket = packet;

            Nibble = new int[packet.Length];
            for (int i = 0; i < packet.Length; i++)
            {
                Nibble[i] = Convert.ToInt16(packet[i].ToString(), 16);
            }

            PktPtr = 0;

            Version = TakeSomeBytes(3);
            TypeId = TakeSomeBytes(3);

            Console.WriteLine($"Version {Version} type {TypeId}");

        }

        private int TakeSomeBytes(int count)
        {
            int retval = 0;

            for (int i = 0; i < count; i++)
            {
                retval = retval | (Nibble[Word(PktPtr)] & BitMask(PktPtr));
                PktPtr++;
              }

            return retval;
        }

        private int Word(int ptr)
        {
            return ptr / 4;
        }

        private int BitMask(int ptr)
        {
            int retval = 0;
            switch ( ptr % 4)
            {
                case 0:
                    retval = 8;
                    break;
                case 1:
                    retval = 4;
                    break;
                case 2:
                    retval = 2;
                    break;
                case 3:
                    retval = 1;
                    break;

            }
            return retval;
        }
    }
}
