using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities
{
    public class Item
    {
        public int Id { get; }
        public string Description { get; }
        public double Price { get; }

        public Item(int id, string description, double price)
        {
            Id = id;
            Description = description;
            Price = price;
        }
    }
}
