using Shop.Entities;
using System;
using System.Linq;

namespace Shop.Entities
{
    public class RingOrder : OrderDecorator
    {
        private readonly Item _ring;

        public RingOrder(Order order, Item ring) : base(order)
        {
            _ring = ring; 
        }

        public override double GetTotalPrice()
        {
            return base.GetTotalPrice() + _ring.Price;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + $", Ring: {_ring.Description}";
        }
    }
}