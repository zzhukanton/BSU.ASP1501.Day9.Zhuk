using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class StringLengthComparer: IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == y)
                return 0;

            return x.Length > y.Length ? 1 : -1;
        }
    }
}
