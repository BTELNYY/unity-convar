using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace UnityConvar
{
    public class ConsoleVariable<T> : GenericConsoleVariable, IEquatable<T>
    {
        private string _name;

        public override string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_nameLocked)
                {
                    return;
                }
                _name = value;
            }
        }

        private bool _nameLocked = false;

        public bool NameLocked
        {
            get
            {
                return _nameLocked;
            }
        }

        public void LockName()
        {
            _nameLocked = true;
        }

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
                if (Flags.HasFlag(ConvarFlags.ReadOnly))
                {
                    return;
                }
                _value = value;
                int index = ConsoleVariableManager.GetVariableIndex(Name);
                ConsoleVariableManager.SetVariable(index, this);
            }
        }

        public sealed override object GetValueGeneric()
        {
            return Value;
        }

        public sealed override void SetValueGeneric(string value, bool forceUpdateOnManager = true)
        {
            if (Flags.HasFlag(ConvarFlags.ReadOnly))
            {
                return;
            }
            T parsedValue = Parse(value);
            Value = parsedValue;
            if (forceUpdateOnManager)
            {
                int index = ConsoleVariableManager.GetVariableIndex(Name);
                ConsoleVariableManager.SetVariable(index, this);
            }
        }

        public virtual T Parse(string value)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        protected void HandleParseError(string value, string message = "No Custom Message")
        {
            throw new ParseException(ValueType, value, message);
        }

        public bool Equals(T other)
        {
            return Value.Equals(other);
        }
    }
}
