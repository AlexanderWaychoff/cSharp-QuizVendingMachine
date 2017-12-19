using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Money
    {
        Money change;
        public Money DetermineMoney(string userInput)
        {
            if (userInput == "penny")
            {
                change = new Penny();
            }
            else if(userInput == "nickel")
            {
                change = new Nickel();
            }
            else if (userInput == "dime")
            {
                change = new Dime();
            }
            else if (userInput == "quarter")
            {
                change = new Quarter();
            }
            return change;
        }
    }
}
