using Shop.Application;
using Shop.Entities;
using Shop.Infrastructure;
using Shop.InterfaceAdapter;
using System;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {

            IJewelryAdapter ringAdapter = new RingAdapter();
            IJewelryAdapter necklaceAdapter = new NecklaceAdapter();
            IWrappingAdapter wrappingAdapter = new WrappingAdapter();
            IShipmentAdapter shipmentAdapter = new ShipmentAdapter();

            LoadItemsUseCase LIUC = new LoadItemsUseCase(ringAdapter, necklaceAdapter, wrappingAdapter, shipmentAdapter);

            Order order = new Order();

            Console.WriteLine("Welcome to the jewelry shop! What type of jewelry would you like to buy?");
            Console.WriteLine("1. Ring");
            Console.WriteLine("2. Necklace");

            int jewelryType = int.Parse(Console.ReadLine());
            Item selectedJewelryItem = null;

            if (jewelryType == 1)
            {
                var ringItems = LIUC.LoadJewelryRingOptions();
                Console.WriteLine("\nAvailable Rings:");
                for (int i = 0; i < ringItems.Count; i++)
                {
                    Console.WriteLine($"{i}: {ringItems[i].Description} - {ringItems[i].Price:C}");
                }

                Console.Write("\nSelect the ring by number: ");
                int selectedRingIndex = int.Parse(Console.ReadLine());
                selectedJewelryItem = ringItems[selectedRingIndex];

                order = new RingOrder(order,selectedJewelryItem);
            }
            else if (jewelryType == 2)
            {
                var necklaceItems = LIUC.LoadJewelryNecklaceOptions();
                Console.WriteLine("\nAvailable Necklaces:");
                for (int i = 0; i < necklaceItems.Count; i++)
                {
                    Console.WriteLine($"{i}: {necklaceItems[i].Description} - {necklaceItems[i].Price:C}");
                }

                Console.Write("\nSelect the necklace by number: ");
                int selectedNecklaceIndex = int.Parse(Console.ReadLine());
                selectedJewelryItem = necklaceItems[selectedNecklaceIndex];

                order = new NecklaceOrder(order, selectedJewelryItem);
            }
            else
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            Console.Write("\nDo you want gift wrapping? (yes/no): ");
            string giftWrapAnswer = Console.ReadLine();

            if (giftWrapAnswer.ToLower() == "yes")
            {
                var wrappingOptions = LIUC.LoadWrappingOptions();
                Console.WriteLine("\nSelect gift wrapping option by number:");

                for (int i = 0; i < wrappingOptions.Count; i++)
                {
                    Console.WriteLine($"{i}: {wrappingOptions[i].Description} - {wrappingOptions[i].Price:C}");
                }

                int wrappingOptionIndex = int.Parse(Console.ReadLine());
                var wrappingItem = wrappingOptions[wrappingOptionIndex];

                order = new GiftWrappedOrder(order, wrappingItem);
            }

            Console.Write("\nDo you want shipment? (yes/no): ");
            string shipmentAnswer = Console.ReadLine();

            if (shipmentAnswer.ToLower() == "yes")
            {
                var shipmentOptions = LIUC.LoadShipmentOptions();
                Console.WriteLine("\nSelect shipment option by number:");

                for (int i = 0; i < shipmentOptions.Count; i++)
                {
                    Console.WriteLine($"{i}: {shipmentOptions[i].Description} - {shipmentOptions[i].Price:C}");
                }

                int shipmentOptionIndex = int.Parse(Console.ReadLine());
                var shipmentItem = shipmentOptions[shipmentOptionIndex];

                order = new ShippedOrder(order, shipmentItem);
            }

            Console.WriteLine("\nOrder Summary:");
            Console.WriteLine(order.GetDescription());
            Console.WriteLine($"\nTotal Price: {order.GetTotalPrice():C}");
            
        }
    }
}