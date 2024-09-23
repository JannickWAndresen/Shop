using Shop.Entities;
using Shop.InterfaceAdapter;
using System.Collections.Generic;

namespace Shop.Application
{
    public class LoadItemsUseCase
    {
        private readonly IJewelryAdapter _ringAdapter;
        private readonly IJewelryAdapter _necklaceAdapter;
        private readonly IWrappingAdapter _wrappingAdapter;
        private readonly IShipmentAdapter _shipmentAdapter;

        public LoadItemsUseCase(IJewelryAdapter ringAdapter, IJewelryAdapter necklaceAdapter,
                                IWrappingAdapter wrappingAdapter, IShipmentAdapter shipmentAdapter)
        {
            _ringAdapter = ringAdapter;
            _necklaceAdapter = necklaceAdapter;
            _wrappingAdapter = wrappingAdapter;
            _shipmentAdapter = shipmentAdapter;
        }

        public List<Item> LoadJewelryRingOptions()
        {
            var allRings = new List<Item>();
            allRings.AddRange(_ringAdapter.GetJewelryItems());     
            return allRings;
        }

        public List<Item> LoadJewelryNecklaceOptions() 
        {
            var allNecklaces = new List<Item>();
            allNecklaces.AddRange(_necklaceAdapter.GetJewelryItems());
            return allNecklaces;
        }

        public List<Item> LoadWrappingOptions()
        {
            return _wrappingAdapter.LoadGiftWrappingOptions();
        }

        public List<Item> LoadShipmentOptions()
        {
            return _shipmentAdapter.LoadShipmentOptions();
        }
    }
}