using System;
namespace _20_TrenchMap
{
    public class ImageEnhancementAlgorithm
    {
        int[] Pixel = new int[512];

        public ImageEnhancementAlgorithm(string line)
        {
            for ( int i = 0; i < 512; i++)
            {
                Pixel[i] = line[i] == '#' ? 1 : 0;
            }
        }

        public int ValueAt ( int i)
        {
            return Pixel[i];
        }
    }
}
