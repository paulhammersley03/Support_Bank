using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support_Bank
{
    class GetReason
    {
        public string Reason(string[] TransactionElement)//Method
        {
            return TransactionElement[3];
        }
    }
}
