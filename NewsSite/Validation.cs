using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite
{
    public class Validation
    {
        public static bool ValidationId(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return true;
        }
    }
}
