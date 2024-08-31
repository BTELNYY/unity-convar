using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityConvar.Attributes;

namespace UnityConvar.BuiltIn
{
    [ConsoleVariableType]
    public class UlongConsoleVariable : ConsoleVariable<ulong>
    {
        public override ulong Parse(string value)
        {
            if(!ulong.TryParse(value, out ulong result))
            {
                HandleParseError(value);
            }
            return result;
        }
    }
}
