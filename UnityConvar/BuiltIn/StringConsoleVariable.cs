using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityConvar.Attributes;

namespace UnityConvar.BuiltIn
{
    [ConsoleVariableType]
    public class StringConsoleVariable : ConsoleVariable<string>
    {
        public override string Parse(string value)
        {
            return value;
        }
    }
}
