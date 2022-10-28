using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulbWPF.Db
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Manufacturer { get; set; }

        public double Price { get; set; }

        public double Discount { get; set; }

        public string ImagePath { get; set; }

    }
}
