using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityConvar.Attributes;

namespace UnityConvar.BuiltIn
{
    [ConsoleVariableType]
    public class ByteConsoleVariable : ConsoleVariable<byte>
    {
        public override byte Parse(string value)
        {
            if(!byte.TryParse(value, out var result))
            {
                HandleParseError(value);
            }
            return result;
        }
    }
}
