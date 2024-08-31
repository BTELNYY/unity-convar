using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityConvar.Attributes;

namespace UnityConvar.BuiltIn
{
    [ConsoleVariableType]
    public class BoolConsoleVariable : ConsoleVariable<bool>
    {
        public override bool Parse(string value)
        {
            if(!bool.TryParse(value, out bool result))
            {
                HandleParseError(value);
            }
            return result;
        }
    }
}
