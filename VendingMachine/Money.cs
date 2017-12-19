using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Money
    {
        public Money change;
        public string amount;
        public double worth;
        public Money()
        {
            this.amount = "";
            this.worth = 0;
        }
        public Money DetermineMoney(string userInput)
        {
            change = new Money();
            if (userInput == "penny")
            {
                change.amount = "penny";
                change.worth = 0.01;
                return change;
            }
            else if(userInput == "nickel")
            {
                change.amount = "nickel";
                change.worth = 0.05;
                return change;
            }
            else if (userInput == "dime")
            {
                change.amount = "dime";
                change.worth = 0.10;
                return change;
            }
            else if (userInput == "quarter")
            {
                change.amount = "quarter";
                change.worth = 0.25;
                return change;
            }
            return change;
        }
    }
}
