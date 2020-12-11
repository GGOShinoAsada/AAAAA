using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAAAA.DAO
{
    public class Product
    {
        public int id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Categories Category { get; set; }
    }
}