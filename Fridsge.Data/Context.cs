using FridgeWarehouse.Data.Entities;
using FridsgeWarehouse.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeWarehouse.Data
{
    public class Context : DbContext
    {
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<FridgeModel> FridgeModels { get; set; }
        public DbSet<Product> Products { get; set; }

        public Context (DbContextOptions<Context> options)
            : base(options)
        {

        }
    }
}
