using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFD_Tools.Types;

public static class Helpers
{
    public static string GetNumberWithLeadingZeroes(int i)
    {
        if (i < 10)
        {
            return $"00{i}";
        }
        else if (i >= 10 && i < 100)
        {
            return $"0{i}";
        }
        else
        {
            return $"{i}";
        }
    }
}
