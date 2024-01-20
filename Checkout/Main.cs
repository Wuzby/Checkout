using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

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
                {"C", 20},
                {"D", 15}
            };

            itemQuantity = new Dictionary<string, int>();

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
            else
            {
                throw new ArgumentException("Item is not present in the Inventroy");
            }
        }

        public int GetTotalPrice()
        {
            int total = 0;

            foreach(var scannedItem in itemQuantity) {

                string item = scannedItem.Key;
                int count = scannedItem.Value;

                if(itemPrices.ContainsKey(item))
                {
                    int itemPrice = itemPrices[item];
                    total += CalculateTotalWithDiscount(item, itemPrice, count);
                }
            
            }

            return total;

        }

        private int CalculateTotalWithDiscount(string item, int itemPrice, int itemCount)
        {
            if (item == "A" && itemCount >= 3)
            {
                int discountedPrice = itemCount / 3;
                return discountedPrice * 130 + (itemCount % 3) * itemPrice;

            }
            else if (item == "B" && itemCount >= 2)
            {
                int discountedPrice = itemCount / 2;
                return discountedPrice * 45 + (itemCount % 2) * itemPrice;

            }
            else
            {
                return itemPrice * itemCount;
            }
        }

    }
}