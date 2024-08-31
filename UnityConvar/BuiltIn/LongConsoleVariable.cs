using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using UnityConvar.Attributes;

namespace UnityConvar.BuiltIn
{
    [ConsoleVariableType]
    public class LongConsoleVariable : ConsoleVariable<long>
    {
        public override long Parse(string value)
        {
            if (!long.TryParse(value, out var longValue))
            {
                HandleParseError(value);
            }
            return longValue;
        }
    }
}
