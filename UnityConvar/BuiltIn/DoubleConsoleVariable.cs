using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityConvar.Attributes;

namespace UnityConvar.BuiltIn
{
    [ConsoleVariableType]
    public class DoubleConsoleVariable : ConsoleVariable<double>
    {
        public override double Parse(string value)
        {
            if(!double.TryParse(value, out double result))
            {
                HandleParseError(value);
            }
            return result;
        }
    }
}
