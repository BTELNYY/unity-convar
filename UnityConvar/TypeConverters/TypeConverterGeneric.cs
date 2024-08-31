using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnityConvar.TypeConverters
{
    public class TypeConverterGeneric
    {
        public static Dictionary<Type, TypeConverterGeneric> Converters = new Dictionary<Type, TypeConverterGeneric>();

        public virtual object Convert(object input)
        {
            throw new NotImplementedException();
        }
    }
}
