using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support_Bank
{
    class GetAmount
    {
        public string Amount(string[] TransactionElement)//Method
        {
            return TransactionElement[4];
        }
    }
}
