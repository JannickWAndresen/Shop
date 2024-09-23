using Shop.Entities;
using Shop.InterfaceAdapter;
using System;
using System.Collections.Generic;
using System.IO; // Make sure to include this for File operations
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure
{
    public class WrappingAdapter : IWrappingAdapter
    {
        private readonly string _filePath = "C:\\Users\\Jannick W. Andresen\\source\\repos\\Shop\\Shop\\Files\\Wrapping.txt";

        public List<Item> LoadGiftWrappingOptions()
        {
            var items = new List<Item>();

            if (File.Exists(_filePath))
            {
                string[] lines = File.ReadAllLines(_filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    items.Add(new Item(int.Parse(parts[0]), parts[1], double.Parse(parts[2])));
                }
            }

            return items;
        }
    }
}