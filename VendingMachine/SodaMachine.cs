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
        private Penny penny = new Penny();
        private Nickel nickel = new Nickel();
        private Dime dime = new Dime();
        private Quarter quarter = new Quarter();
        public int pennies = 0;
        public int nickels = 0;
        public int dimes = 0;
        public int quarters = 0;
        public SodaMachine()
        {
            MachineCoinStock AvailableChange = new MachineCoinStock(50, 20, 10, 20);
        }
        public void InsertedCoins(string playerInput)
        {
            pennies = 0;
            nickels = 0;
            dimes = 0;
            quarters = 0;
            foreach (Money coin in insertedCoins)
            {
                if (coin.worth == penny.worth)
                    pennies += 1;
                if (coin.worth == nickel.worth)
                    nickels += 1;
                if (coin.worth == dime.worth)
                    dimes += 1;
                if (coin.worth == quarter.worth)
                    quarters += 1;
            }
            Console.WriteLine("You have inserted {0} pennies, {1} nickels, {2} dimes and {3} quarters.", pennies, nickels, dimes, quarters);
            Console.WriteLine(insertedCoins.Count);
        }
        public void ClearInsertedCoins()
        {
            pennies = 0;
            nickels = 0;
            dimes = 0;
            quarters = 0;
            insertedCoins.Clear();
        }
    }
}
