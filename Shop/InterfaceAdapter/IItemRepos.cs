using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.InterfaceAdapter
{
    public interface IItemRepository
    {
        List<Item> LoadItems();
        void SaveItems(List<Item> items);
    }
}
