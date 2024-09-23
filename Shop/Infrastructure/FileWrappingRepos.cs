using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure
{
        public class FileWrappingRepos
        {
            private readonly string _filePath;

            public FileWrappingRepos(string filePath)
            {
                _filePath = filePath;
            }

            public double GetWrappingCost()
            {
                var lines = File.ReadAllLines(_filePath);

                return double.Parse(lines[0]);
            }
        }

        public class FileShipmentRepos
        {
            private readonly string _filePath;

            public FileShipmentRepos(string filePath)
            {
                _filePath = filePath;
            }

            public double GetShippingCost()
            {
                var lines = File.ReadAllLines(_filePath);

                return double.Parse(lines[0]);
            }
        }
    }