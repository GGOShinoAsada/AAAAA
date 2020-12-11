using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAAAA.DAO
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Categories()
        {
            Products = new List<Product>();
        }
    }
}