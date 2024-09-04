using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityConvar.Attributes;

namespace UnityConvar.BuiltIn
{
    [ConsoleVariableType]
    public class ConsoleVariableArray<T> : ConsoleVariable<IEnumerable<T>>, IEnumerable<T> where T : GenericConsoleVariable
    {
        public ConsoleVariableArray(IEnumerable<T> values)
        {
            Value = values;
        }

        public virtual string Delimeter { get; } = "|";

        public override string ToString()
        {
            string final = "";
            foreach(GenericConsoleVariable item in Value)
            {
                final += "\"";
                final += item.ToString();
                final += "\"";
                if (Value.Last() != item)
                {
                    final += Delimeter;
                }
            }
            return final;
        }

        public override IEnumerable<T> Parse(string value)
        {
            return base.Parse(value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Value.GetEnumerator();
        }
    }
}
