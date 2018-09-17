using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Functions.Domain
{
    public class EngageAPIReturnObject
    {
        public EngageAPIReturnObject()
        {
            APICallReturnStatus = new List<CallReturnObject>();
        }


        public NarsUser User { get; set; }
        public List<NarsCall> Calls { get; set; }

        public List<CallReturnObject> APICallReturnStatus { get; set; }
    }
}
