using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities
{
    public class ShippedOrder : OrderDecorator
    {
        private readonly Item _shipment;

        public ShippedOrder(Order order, Item shipment) : base(order)
        {
            _shipment = shipment;
        }

        public override double GetTotalPrice()
        {
            return base.GetTotalPrice() + _shipment.Price;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + $", Shipment: {_shipment.Description}";
        }
    }
}
