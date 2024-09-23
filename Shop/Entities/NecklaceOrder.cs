using Shop.Entities;
using System;
using System.Linq;

namespace Shop.Entities
{
    public class NecklaceOrder : OrderDecorator
    {
        private readonly Item _necklace;

        public NecklaceOrder(Order order, Item necklace) : base(order) 
        {
            _necklace = necklace;
        }

        public override double GetTotalPrice()
        {
            return base.GetTotalPrice() + _necklace.Price;  
        }

  
        public override string GetDescription()
        {
            return base.GetDescription() + $", Necklace: {_necklace.Description}"; 
        }
    }
}