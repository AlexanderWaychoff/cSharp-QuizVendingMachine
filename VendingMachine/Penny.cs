using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Penny : Money
    {
        public string amount;
        public double worth;
        public Penny()
        {
            this.amount = "penny";
            this.worth = 0.01;
        }
    }
}
