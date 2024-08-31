using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityConvar.Attributes;

namespace UnityConvar.BuiltIn
{
    [ConsoleVariableType]
    public class FloatConsoleVariable : ConsoleVariable<float>
    {
        public override float Parse(string value)
        {
            if (!float.TryParse(value, out var result))
            {
                HandleParseError(value);
            }
            return result;
        }
    }
}
