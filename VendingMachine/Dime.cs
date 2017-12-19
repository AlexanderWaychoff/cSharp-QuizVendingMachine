using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Dime : Money
    {
        public string amount;
        public double worth;
        public Dime()
        {
            this.amount = "dime";
            this.worth = 0.10;
        }
    }
}
