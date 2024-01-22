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
        //Dictionary that store items and their prices
        //Dictionary that keeps track of which items are bought and their quantity
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
        //Scans item by checking if the item exists in the dictionary
        //if it does, check quantity dictionary to see if it exists if yes increment by 1
        //if not then make a new record of it
        //and if item is not present in the list of dictionary with prices it will throw an error
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

            foreach(var scannedItem in itemQuantity) {                                  //Loop over the dictionary for items and their values
                                                                                        //store item and value in separate variables
                string item = scannedItem.Key;                                          //Check item price dictionary for the item
                int count = scannedItem.Value;                                          //store the value of the item in a variable
                                                                                        //before adding price to total check for the special discount
                if(itemPrices.ContainsKey(item))
                {
                    int itemPrice = itemPrices[item];
                    total += CalculateTotalWithDiscount(item, itemPrice, count);
                }
            
            }

            return total;

        }
        //Takes into account discount when calculation total  for items if conditionas are met
        private int CalculateTotalWithDiscount(string item, int itemPrice, int itemCount)
        {
            if (item == "A" && itemCount >= 3)                                  //Checks if item "A" is encountered 3 or more times
            {                                                                   //checks how many times tripple A is present
                int discountedPrice = itemCount / 3;                            //returns price for the number of times it encountered A plus calculates
                return discountedPrice * 130 + (itemCount % 3) * itemPrice;     //the price for the 
                                                                                //Does the same for item B
            }                                                                   //if no conditions met returns regular price
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