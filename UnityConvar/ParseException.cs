using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityConvar
{
    public class ParseException : Exception
    {
        public Type ExpectedType { get; set; }

        public string StringRecieved { get; set; }
        
        public string CustomMessage { get; set; }

        public ParseException(Type expectedType, string stringRecieved) : base($"Can't parse {stringRecieved} to {expectedType.FullName}! Custom Message:")
        {
            ExpectedType = expectedType;
            StringRecieved = stringRecieved;
        }

        public ParseException() : base("Parse error!")
        {
            
        }

        public ParseException(string message) : base(message) { }

        public ParseException(Type expectedType, string stringRecieved, string customMessage) : base($"Can't parse {stringRecieved} to {expectedType.FullName}! Custom Message: {customMessage}")
        { 
            ExpectedType = expectedType;
            StringRecieved = stringRecieved;
            CustomMessage = customMessage;
        }
    }
}
