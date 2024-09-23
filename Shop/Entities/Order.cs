using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities
{
    public class Order
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public double TotalPrice { get; set; }

        public virtual string GetDescription()
        {
            return string.Join(", ", Items.Select(i => i.Description));
        }

        public virtual double GetTotalPrice()
        {
            return Items.Sum(i => i.Price);
        }
    }
}
