using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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



        public virtual char Delimeter { get; } = ',';

        public virtual char BeginningSymbol { get; } = '[';

        public virtual char EndingSymbol { get; } = ']';

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
            List<string> result = new List<string>();
            StringBuilder currentItem = new StringBuilder();
            int depth = 0;
            foreach (char c in value)
            {
                if (c == BeginningSymbol)
                {
                    if (depth > 0)
                    {
                        currentItem.Append(c);
                    }
                    depth++;
                }
                else if (c == EndingSymbol)
                {
                    depth--;
                    if (depth > 0)
                    {
                        currentItem.Append(c);
                    }
                    else if (depth == 0)
                    {
                        result.Add(currentItem.ToString());
                        currentItem.Clear();
                    }
                }
                else if (c == Delimeter && depth == 0)
                {
                    result.Add(currentItem.ToString());
                    currentItem.Clear();
                }
                else
                {
                    currentItem.Append(c);
                }
            }

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
