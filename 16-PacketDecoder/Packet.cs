using System;
using System.Collections.Generic;

namespace _16_PacketDecoder
{
    public class Packet
    {
        public string RawPacket;

        public BitStream Stream;

        public ulong Version;
        public ulong TypeId;

        public ulong Value;

        public Packet(BitStream stream)
        {
            Stream = stream;
            DecodePacket();
        }

        public void DecodePacket()
        {
            Version = Stream.ReadValue(3);
            TypeId = Stream.ReadValue(3);

            Console.WriteLine($"{Version} {TypeId}   pointer={Stream.BitPtr,4}");

            if (TypeId == 4)    //literal value
            {
                Value = Stream.ReadLiteral();
            }
            else
            {
                List<Packet> subPackets = new List<Packet>();

                if (Stream.ReadBit() == 1)   // LengthTypeId
                {
                    ulong subCount = Stream.ReadValue(11);
                    for (ulong i = 0; i < subCount; i++)
                    {
                        subPackets.Add(new Packet(Stream));
                    }
                }
                else
                {
                    ulong targetBit = Stream.ReadValue(15);
                    targetBit += Stream.BitPtr;

                    do
                    {
                        subPackets.Add(new Packet(Stream));
                    }
                    while (Stream.BitPtr < targetBit);
                }

                try
                {
                    switch (TypeId)
                    {
                        case 0:       // sum
                            ulong sum = 0;
                            foreach (var p in subPackets)
                                sum += p.Value;
                            Value = sum;
                            break;

                        case 1:       // product
                            ulong prod = 1;
                            foreach (var p in subPackets)
                                prod *= p.Value;
                            Value = prod;
                            break;

                        case 2:       // minimum
                            ulong min = ulong.MaxValue;
                            foreach (var p in subPackets)
                                if (p.Value < min)
                                    min = p.Value;
                            Value = min;
                            break;

                        case 3:       // maximum
                            ulong max = ulong.MinValue;
                            foreach (var p in subPackets)
                                if (p.Value > max)
                                    max = p.Value;
                            Value = max;
                            break;

                        case 5:       // greater than
                            Value = (ulong)(subPackets[0].Value > subPackets[1].Value ? 1 : 0);
                            break;

                        case 6:       // less than
                            Value = (ulong)(subPackets[0].Value < subPackets[1].Value ? 1 : 0);
                            break;

                        case 7:       // equal to
                            Value = (ulong)(subPackets[0].Value == subPackets[1].Value ? 1 : 0);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
