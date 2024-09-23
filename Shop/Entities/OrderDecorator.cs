using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities
{
    public abstract class OrderDecorator : Order
    {
        protected Order _order;

        public OrderDecorator(Order order)
        {
            _order = order;
        }

        public override string GetDescription()
        {
            return _order.GetDescription();
        }

        public override double GetTotalPrice()
        {
            return _order.GetTotalPrice();
        }
    }
}
