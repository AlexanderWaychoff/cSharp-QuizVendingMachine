using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Quarter : Money
    {
        public string amount;
        public double worth;
        public Quarter()
        {
            this.amount = "quarter";
            this.worth = 0.25;
        }
    }
}
