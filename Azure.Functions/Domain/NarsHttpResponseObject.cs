using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Functions.Domain
{
    public class NarsHttpResponseObject
    {
        public string ReturnType { get; set; }
        public bool Success { get; set; }
        public Exception Exception { get; set; }
        public object ReturnObject { get; set; }
    }
}
