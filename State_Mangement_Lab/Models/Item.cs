using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace State_Mangement_Lab.Models
{
    public class Item
    {
        public string ItemName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Item(string itemName, string description, double price)
        {
            ItemName = itemName;
            Description = description;
            Price = price;
        }

        public Item() { }

    }
}