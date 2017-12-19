using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Nickel : Money
    {
        public string amount;
        public double worth;
        public Nickel()
        {
            this.amount = "nickel";
            this.worth = 0.05;
        }
    }
}
