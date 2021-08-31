using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAlong_Template.Models
{
    public static class FeverStatic
    {
        public static bool IsValid(float? val)
        {
            bool result = true;
            if (val==null)
            {
                result = false;
            }
            return result;
        }
    }
}
