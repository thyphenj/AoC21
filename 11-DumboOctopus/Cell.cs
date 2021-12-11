using System;
namespace _11_DumboOctopus
{
    public class Cell
    {
        public int Value;
        public bool FlashRequired;
        public bool FlashPerformed;

        public Cell(int value)
        {
            FlashRequired = false;
            FlashPerformed = false;
            Value = value;
        }
        public void Increment()
        {
            if (Value++ == 9) FlashRequired = true; ;
        }
        public int Flash()
        {
            if (FlashRequired && !FlashPerformed)
            {
                FlashPerformed = true;
                FlashRequired = false;
                return 1;
            }
            return 0;
        }
        public int AdjustFlashed()
        {
            int retval = 0;
            if (Value > 9)
            {
                FlashRequired = false;
                FlashPerformed = false;
                Value = 0;
                retval = 1;
            }
            return retval;
        }
        public override string ToString()
        {
            return $"{Value,2}";
        }
    }
}
