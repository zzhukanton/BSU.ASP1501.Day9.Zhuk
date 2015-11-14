using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class DigitNumberComparer: IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x == y)
                return 0;

            if (Length(x) > Length(y))
                return 1;
            else
                return -1;
        }

        private static int Length(int num)
        {
            int count = 0;
            while (num != 0)
            {
                num /= 10;
                count++;
            }
            return count;
        }
    }
}
