using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AAAAA.DAO;

namespace AAAAA.Controllers
{
    public class Context:DbContext
    {
        public DbSet<Categories> CategoriesContext { get; set; }
        public DbSet<Product> ProductContext { get; set; }
    }
}