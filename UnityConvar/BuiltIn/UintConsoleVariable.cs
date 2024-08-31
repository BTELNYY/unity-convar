using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityConvar.Attributes;

namespace UnityConvar.BuiltIn
{
    [ConsoleVariableType]
    public class UintConsoleVariable : ConsoleVariable<uint>
    {
        public override uint Parse(string value)
        {
            if(!uint.TryParse(value, out uint result))
            {
                HandleParseError(value);
            }
            return result;
        }
    }
}
