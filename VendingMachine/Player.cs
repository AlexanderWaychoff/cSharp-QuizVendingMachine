using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Player
    {
        public Wallet wallet = new Wallet(250, 320, 110, 420);
        private Penny penny = new Penny();
        private Nickel nickel = new Nickel();
        private Dime dime = new Dime();
        private Quarter quarter = new Quarter();

        public Player()
        {

        }
        public void ManageMoney(string playerInput, SodaMachine sodaMachine)
        {
            if (playerInput == "cancel")
            {
                Console.WriteLine("\n\n****Transaction canceled.  Refunding money.****\n\n");
                ReturnChange(sodaMachine);
            }
            else
            {
                Money change = new Money();
                change = change.DetermineMoney(playerInput);
                if (change.worth == penny.worth)
                {
                    wallet.pennies.RemoveAt(0);
                    sodaMachine.insertedCoins.Add(change);
                }
                if (change.worth == nickel.worth)
                {
                    wallet.nickels.RemoveAt(0);
                    sodaMachine.insertedCoins.Add(change);
                }
                if (change.worth == dime.worth)
                {
                    wallet.dimes.RemoveAt(0);
                    sodaMachine.insertedCoins.Add(change);
                }
                if (change.worth == quarter.worth)
                {
                    wallet.quarters.RemoveAt(0);
                    sodaMachine.insertedCoins.Add(change);
                }
            }
        }
        private void ReturnChange(SodaMachine sodaMachine)
        {
            foreach (Money coin in sodaMachine.insertedCoins)
            {
                if (coin.worth == penny.worth)
                    wallet.pennies.Add(penny);
                if (coin.worth == nickel.worth)
                    wallet.nickels.Add(nickel);
                if (coin.worth == dime.worth)
                    wallet.dimes.Add(dime);
                if (coin.worth == quarter.worth)
                    wallet.quarters.Add(quarter);
            }
            sodaMachine.ClearInsertedCoins();
        }
    }
}
