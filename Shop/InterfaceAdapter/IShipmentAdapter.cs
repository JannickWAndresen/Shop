using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.InterfaceAdapter
{
    public interface IShipmentAdapter
    {
        List<Item> LoadShipmentOptions();
    }
}
