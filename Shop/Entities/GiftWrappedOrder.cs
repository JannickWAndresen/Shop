using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities
{
    public class GiftWrappedOrder : OrderDecorator
    {
        private readonly Item _wrapping;

        public GiftWrappedOrder(Order order, Item wrapping) : base(order)
        {
            _wrapping = wrapping;
        }

        public override double GetTotalPrice()
        {
            return base.GetTotalPrice() + _wrapping.Price; 
        }

        public override string GetDescription()
        {
            return base.GetDescription() + $", Gift Wrapping: {_wrapping.Description}";
        }
    }
}
