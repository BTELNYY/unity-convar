using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityConvar.Attributes;

namespace UnityConvar.BuiltIn
{
    [ConsoleVariableType]
    public class IntConsoleVariable : ConsoleVariable<int>
    {
        public override int Parse(string value)
        {
            if (!int.TryParse(value, out var i))
            {
                HandleParseError(value);
            }
            return i;
        }
    }
}
