using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Functions.Domain
{
    public class ReturnObject
    {
        public NarsUser User { get; set; }
        public List<NarsCall> Calls { get; set; }

        public Exception Exception { get; set; }
        public string ResponseString { get; set; }
        public String Message { get; set; }
        public bool Success { get; set; }
    }
}
