using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class SodaMachine
    {
        public List<Money> insertedCoins = new List<Money>();
        private Money penny;
        private Money nickel;
        private Money dime;
        private Money quarter;
        private int pennies = 0;
        private int nickels = 0;
        private int dimes = 0;
        private int quarters = 0;
        public SodaMachine()
        {
            MachineCoinStock AvailableChange = new MachineCoinStock(50, 20, 10, 20);
        }
        public void InsertedCoins()
        {
            foreach (var coin in insertedCoins)
            {
                if (coin == penny)
                    pennies += 1;
                if (coin == nickel)
                    nickels += 1;
                if (coin == dime)
                    dimes += 1;
                if (coin == quarter)
                    quarters += 1;
            }
            Console.WriteLine("You have inserted {0} pennies, {1} nickels, {2} dimes and {3} quarters.", pennies, nickels, dimes, quarters);
        }
    }
}
