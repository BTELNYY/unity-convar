using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace UnityConvar
{
    public class ConsoleVariable<T> : GenericConsoleVariable, IEquatable<T>
    {
        public override Type ValueType => typeof(T);

        public virtual T DefaultValue { get; } = default(T);

        T _value;

        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public sealed override object GetValueGeneric()
        {
            return Value;
        }

        public sealed override void SetValueGeneric(string value)
        {
            T parsedValue = Parse(value);
            Value = parsedValue;
        }

        public virtual T Parse(string value)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        protected void HandleParseError(string value)
        {
            throw new ParseException(ValueType, value);
        }

        public bool Equals(T other)
        {
            return Value.Equals(other);
        }
    }
}
