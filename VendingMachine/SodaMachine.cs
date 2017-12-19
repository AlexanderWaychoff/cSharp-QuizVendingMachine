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
        private List<Money> backupInsertedCoins = new List<Money>();
        private Penny penny = new Penny();
        private Nickel nickel = new Nickel();
        private Dime dime = new Dime();
        private Quarter quarter = new Quarter();
        MachineCoinStock availableChange;
        bool hasQuarters = true;
        bool hasDimes = true;
        bool hasNickels = true;
        bool hasPennies = true;
        bool transactionFailed = false;
        public int pennies = 0;
        public int nickels = 0;
        public int dimes = 0;
        public int quarters = 0;
        int removedQuarters = 0;
        int removedDimes = 0;
        int removedNickels = 0;
        int removedPennies = 0;
        private double totalValue = 0;
        private double grapeSodaCost = 0.60;
        private double orangeSodaCost = 0.35;
        private double lemonSodaCost = 0.06;
        public int grapeSodaCount = 10;
        public int orangeSodaCount = 10;
        public int lemonSodaCount = 10;
        public SodaMachine()
        {
            availableChange = new MachineCoinStock(50, 20, 10, 20);
        }
        public void InsertedCoins(string playerInput)
        {
            totalValue = 0;
            pennies = 0;
            nickels = 0;
            dimes = 0;
            quarters = 0;
            foreach (Money coin in insertedCoins)
            {
                if (coin.worth == penny.worth)
                {
                    totalValue += penny.worth;
                    pennies += 1;
                }
                if (coin.worth == nickel.worth)
                {
                    totalValue += nickel.worth;
                    nickels += 1;
                }
                if (coin.worth == dime.worth)
                {
                    totalValue += dime.worth;
                    dimes += 1;
                }
                if (coin.worth == quarter.worth)
                {
                    totalValue += quarter.worth;
                    quarters += 1;
                }
            }
            Console.WriteLine("You have inserted {0} pennies, {1} nickels, {2} dimes and {3} quarters.", pennies, nickels, dimes, quarters);
            Console.WriteLine(insertedCoins.Count);
        }
        public void ReturnChange(Wallet wallet)
        {
            foreach (Money coin in insertedCoins)
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
            ClearInsertedCoins();
        }
        public void ClearInsertedCoins()
        {
            pennies = 0;
            nickels = 0;
            dimes = 0;
            quarters = 0;
            insertedCoins.Clear();
        }
        public void BuySoda(string playerInput, Wallet wallet)
        {
            if(totalValue >= grapeSodaCost && playerInput == "grape" && grapeSodaCount > 0)
            {
                RemoveInsertedCoins(grapeSodaCost, wallet);
                ReturnChange(wallet);
                ClearInsertedCoins();
                if (!transactionFailed)
                {
                    Console.WriteLine("Enjoy your grape soda.\n\n");
                    grapeSodaCount -= 1;
                }
            }
            else if (totalValue >= orangeSodaCost && playerInput == "orange" && orangeSodaCount > 0)
            {
                RemoveInsertedCoins(orangeSodaCost, wallet);
                ReturnChange(wallet);
                ClearInsertedCoins();
                if (!transactionFailed)
                {
                    Console.WriteLine("Enjoy your orange soda.\n\n");
                    orangeSodaCount -= 1;
                }
            }
            else if (totalValue >= lemonSodaCost && playerInput == "lemon" && lemonSodaCount > 0)
            {
                RemoveInsertedCoins(lemonSodaCost, wallet);
                ReturnChange(wallet);
                ClearInsertedCoins();
                if (!transactionFailed)
                {
                    Console.WriteLine("Enjoy your lemon soda.\n\n");
                    lemonSodaCount -= 1;
                }
            }
            else
            {
                Console.WriteLine("You don't have enough inserted to buy any soda yet or the vending machine is out of stock.");
            }
        }
        private void RemoveInsertedCoins(double sodaCost, Wallet wallet)
        {
            transactionFailed = false;
            backupInsertedCoins = insertedCoins;
            while(sodaCost >= 0.01)
            {
                foreach (var coin in insertedCoins.ToList())
                {
                    if (coin.worth == quarter.worth)
                    {
                        sodaCost -= quarter.worth;
                        insertedCoins.Remove(coin);
                    }
                    if (coin.worth == dime.worth)
                    {
                        sodaCost -= quarter.worth;
                        insertedCoins.Remove(coin);
                    }
                    if (coin.worth == nickel.worth)
                    {
                        sodaCost -= quarter.worth;
                        insertedCoins.Remove(coin);
                    }
                    if (coin.worth == penny.worth)
                    {
                        sodaCost -= quarter.worth;
                        insertedCoins.Remove(coin);
                    }
                }
            }
            while (sodaCost < -0.01)
            {
                CheckAvailableChange();
                if (sodaCost <= quarter.worth * -1 && hasQuarters)
                {
                    removedQuarters += 1;
                    availableChange.quarters.RemoveAt(0);
                    wallet.quarters.Add(quarter);
                    sodaCost += quarter.worth;
                }
                else if (sodaCost <= dime.worth * -1 && hasDimes)
                {
                    removedDimes += 1;
                    availableChange.dimes.RemoveAt(0);
                    wallet.dimes.Add(quarter);
                    sodaCost += dime.worth;
                }
                else if (sodaCost <= nickel.worth * -1 && hasNickels)
                {
                    removedNickels += 1;
                    availableChange.nickels.RemoveAt(0);
                    wallet.nickels.Add(quarter);
                    sodaCost += nickel.worth;
                }
                else if (sodaCost <= penny.worth * -1 && hasPennies)
                {
                    removedPennies += 1;
                    availableChange.pennies.RemoveAt(0);
                    wallet.pennies.Add(quarter);
                    sodaCost += penny.worth;
                }
                else
                {
                    insertedCoins = backupInsertedCoins;
                    ReturnChange(wallet);
                    Console.WriteLine("There isn't enough change available in the vending machine to complete this transaction.  Refunding money.\n\n");
                    ResetChange();
                    transactionFailed = true;
                }
            }
        }
        public void CheckAvailableChange()
        {
            if (availableChange.quarters.Count == 0)
                hasQuarters = false;
            else
                hasQuarters = true;
            if (availableChange.dimes.Count == 0)
                hasDimes = false;
            else
                hasDimes = true;
            if (availableChange.nickels.Count == 0)
                hasNickels = false;
            else
                hasNickels = true;
            if (availableChange.pennies.Count == 0)
                hasPennies = false;
            else
                hasPennies = true;
        }
        public void ResetChange()
        {
            for (int i = 0; i < removedPennies; i++)
                availableChange.pennies.Add(penny);
            for (int j = 0; j < removedNickels; j++)
                availableChange.nickels.Add(nickel);
            for (int k = 0; k < removedDimes; k++)
                availableChange.dimes.Add(dime);
            for (int l = 0; l < removedQuarters; l++)
                availableChange.quarters.Add(quarter);
        }

    }
}
