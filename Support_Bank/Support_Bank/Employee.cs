using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support_Bank
{
    public class Employee
    {
        public string Name { get; set; }
        public decimal BalanceOwedFrom { get; set; }
        public decimal BalanceOwedTo { get; set; }

        public decimal GetBalanceTotal()
        {
            return BalanceOwedFrom - BalanceOwedTo;
        }
    }
}
