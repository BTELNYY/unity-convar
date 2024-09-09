using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityConvar
{
    public class GenericConsoleVariable
    {
        public virtual string Name
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual Type ValueType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public virtual ConvarFlags Flags { get; set; } = ConvarFlags.None;

        public virtual void SetValueGeneric(string value, bool forceUpdateOnManager = true)
        {
            throw new NotImplementedException();
        }

        public virtual object GetValueGeneric()
        {
            throw new NotImplementedException();
        }
    }

    [Flags]
    public enum ConvarFlags
    {
        None = 0,
        ReadOnly,
        Hidden,
    }
}
