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
        private Money penny;
        private Money nickel;
        private Money dime;
        private Money quarter;

        public Player()
        {

        }
        public void ManageMoney(string playerInput, SodaMachine sodaMachine)
        {
            if(playerInput == "penny")
            {
                wallet.pennies.RemoveAt(0);
                sodaMachine.insertedCoins.Add(penny);
            }
            if (playerInput == "nickel")
            {
                wallet.nickels.RemoveAt(0);
                sodaMachine.insertedCoins.Add(nickel);
            }
            if (playerInput == "dime")
            {
                wallet.dimes.RemoveAt(0);
                sodaMachine.insertedCoins.Add(dime);
            }
            if (playerInput == "quarter")
            {
                wallet.quarters.RemoveAt(0);
                sodaMachine.insertedCoins.Add(quarter);
            }
        }
    }
}
