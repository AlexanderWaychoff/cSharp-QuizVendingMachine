using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class PlayGame
    {
        SodaMachine sodaMachine = new SodaMachine();
        Player player = new Player();
        string playerInput;
        public void RunGame()
        {
            while (playerInput != "stop")
            {
                DisplayAvailableMoney();
                DisplaySodaCost();
                AskPlayerForMoney();
                playerInput = Console.ReadLine();
                Console.Clear();
                player.ManageMoney(playerInput, sodaMachine);
                sodaMachine.InsertedCoins(playerInput);
            }
        }
        public void AskPlayerForMoney()
        {
            Console.WriteLine("Enter 'penny', 'nickel', 'dime', or 'quarter' to insert money into the Soda Machine.  Enter 'cancel' to get money you put in back, or enter 'stop' to end the program.");
        }
        public void DisplayAvailableMoney()
        {
            Console.WriteLine("You have {0} pennies, {1} nickels, {2} dimes and {3} quarters.", player.wallet.pennies.Count, player.wallet.nickels.Count, player.wallet.dimes.Count, player.wallet.quarters.Count);
        }
        public void DisplaySodaCost()
        {
            Console.WriteLine("Soda Machine costs (type desired drink to attempt to buy): \ngrape - 60 cents\norange - 35 cents\nlemon - 6 cents");
        }
        public void RemoveCoinFromWallet(string playerInput)
        {
            //player class function(playerInput)
        }
    }
}
