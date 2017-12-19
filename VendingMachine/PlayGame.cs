using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class PlayGame
    {
        Player player = new Player();
        string playerInput;
        public void RunGame()
        {
            while (playerInput != "stop")
            {
                DisplayAvailableMoney();
                playerInput = Console.ReadLine();
            }
        }
        public void AskPlayerForMoney()
        {

        }
        public void DisplayAvailableMoney()
        {
            Console.WriteLine("You have {0} pennies, {1} nickels, {2} dimes and {3} quarters.", player.wallet.pennies.Count, player.wallet.nickels.Count, player.wallet.dimes.Count, player.wallet.quarters.Count);
        }
    }
}
