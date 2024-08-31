using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityConvar.TypeConverters
{
    /// <summary>
    /// Provides the ability to convert between two custom types which the default C# <see cref="Convert.ChangeType(object, Type)"/> can't do anything with. Note, you should be able to go back and fourth.
    /// </summary>
    /// <typeparam name="T1">
    /// Type 1
    /// </typeparam>
    /// <typeparam name="T2">
    /// Type 2
    /// </typeparam>
    public class TypeConverter<T1, T2> : TypeConverterGeneric
    {
        public sealed override object Convert(object input)
        {
            if(input.CanCastTo(typeof(T1)))
            {
                return Convert((T1)input);
            }
            if(input.CanCastTo(typeof(T2)))
            {
                return Convert((T2)input);
            }
            throw new ArgumentException("Input does not match the TypeConverter Spec.", "input");
        }

        public virtual T1 Convert(T2 input)
        {
            throw new NotImplementedException();
        }

        public virtual T2 Convert(T1 input)
        {
            throw new NotImplementedException();
        }
    }
}
