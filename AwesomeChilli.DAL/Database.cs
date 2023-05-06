using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.DAL
{
    public class Database : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("awesome");
        }

        public DbSet<CommodityEntity> Commodities { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ManufacturerEntity> Manufacturers { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
    }
}
