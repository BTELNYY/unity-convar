using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace UnityConvar
{
    public class ConsoleVariable<T> : GenericConsoleVariable
    {
        public sealed override Type ValueType => typeof(T);

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

        public override object GetValueGeneric()
        {
            return Value;
        }

        public override void SetValueGeneric(object value)
        {
            T parsedValue = Parse(value);
            Value = parsedValue;
        }

        public T Parse(object value)
        {
            if (!IsValid(value))
            {
                return default(T);
            }
            if(value is T parsed)
            {
                return parsed;
            }
            if (value.GetType().IsAssignableFrom(typeof(T)))
            {
                return (T)value;
            }
            object result = Convert.ChangeType(value, typeof(T));
            if(result != null)
            {
                return (T)result;
            }
            T convertCustom = ConvertCustom(value);
            if(convertCustom != null)
            {
                return convertCustom;
            }
            throw new InvalidCastException("The specified value type for the convar is not correct.");
        }

        public virtual bool IsValid(object value)
        {
            if(value == null)
            {
                return false;
            }
            return true;
        }

        protected virtual T ConvertCustom(object value)
        {
            return default;
        }
    }
}
