using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Functions.Domain
{
    public class CallReturnObject
    {
        public CallReturnObject()
        {
            //default ctor;
        }

        public CallReturnObject(string CallName, NarsHttpResponseObject response)
        {
            Success = response.Success;
            ReturnObjectType = response.ReturnType;
            APIName = "CallNarsUser";
            Exception = response.Exception;
        }


        public string APIName { get; set; }
        public bool Success { get; set; }
        public string ReturnObjectType { get; set; }
        public Exception Exception { get; set; }
    }
}
