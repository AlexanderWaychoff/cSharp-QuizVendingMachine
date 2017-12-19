using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class MachineCoinStock
    {
        Penny penny = new Penny();
        Nickel nickel = new Nickel();
        Dime dime = new Dime();
        Quarter quarter = new Quarter();
        public List<Money> pennies = new List<Money>();
        public List<Money> nickels = new List<Money>();
        public List<Money> dimes = new List<Money>();
        public List<Money> quarters = new List<Money>();
        public MachineCoinStock(int pennyCount, int nickelCount, int dimeCount, int quarterCount)
        {
            for (int i = 0; i < pennyCount; i++)
                pennies.Add(penny);
            for (int j = 0; j < nickelCount; j++)
                nickels.Add(nickel);
            for (int k = 0; k < dimeCount; k++)
                dimes.Add(dime);
            for (int l = 0; l < quarterCount; l++)
                quarters.Add(quarter);
        }
    }
}
