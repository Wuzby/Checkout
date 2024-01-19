using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    internal class Main : ICheckOut
    {
        private Dictionary<string, int> itemPrices;
        private Dictionary<string, int> itemQuantity;

        public Main()
        {
            itemPrices = new Dictionary<string, int>
            {
                {"A", 50},
                {"B", 30},
                {"C", 10},
                {"D", 15}
            };

            itemQuantity = new Dictionary<string, int>();

        }

        public int GetTotalPrice()
        {
            int total = 0;

            foreach(var scannedItem in itemQuantity) {

                string item = scannedItem.Key;
                int count = scannedItem.Value;

                if(itemPrices.TryGetValue(item, out int itemPrice))
                {

                    total += count * itemPrice;
                }
            
            }

            return total;

        }

        public void Scan(string item)
        {
            if (itemPrices.ContainsKey(item))
            {
                if(itemQuantity.TryGetValue(item, out int count))
                {
                    itemQuantity[item] = count + 1;
                }
                else
                {

                    itemQuantity[item] = 1;
                }
            }
        }
    }
}