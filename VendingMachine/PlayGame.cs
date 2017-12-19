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
                while (playerInput != "stop")
                {
                    AskPlayerForMoney();
                    playerInput = Console.ReadLine();
                    player.ManageMoney(playerInput, sodaMachine);
                    DisplayAvailableMoney();
                    sodaMachine.InsertedCoins(playerInput);
                }
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
            Console.WriteLine("Soda Machine costs: \nGrape - 60 cents\nOrange - 35 cents\nLemon - 6 cents");
        }
        public void RemoveCoinFromWallet(string playerInput)
        {
            //player class function(playerInput)
        }
    }
}
