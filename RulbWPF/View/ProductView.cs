using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulbWPF.View
{
    public class ProductView
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Manufacturer { get; set; }

        public double Price { get; set; }

        public double Discount { get; set; }

        public string ImagePath { get; set; }

        public double PriceWithSale { get; set; }
    }
}
