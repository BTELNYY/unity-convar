using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityConvar
{
    public static class Extensions
    {
        public static bool CanCastTo(this object obj, Type type)
        {
            return !Convert.ChangeType(obj, type).Equals(null);
        }
    }
}
