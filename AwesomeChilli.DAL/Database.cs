using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.DAL
{
    internal class Database
    {
        private static readonly Lazy<Database> _LazyDatabase = new Lazy<Database>(() => new Database());

        public static Database Instance => _LazyDatabase.Value;

        public Database()
        {
        }


        public ICollection<CommodityEntity> Commodities { get; } = new List<CommodityEntity>();
        public ICollection<CategoryEntity> Categories { get; } = new List<CategoryEntity>();
        public ICollection<ManufacturerEntity> Manufacturers { get; } = new List<ManufacturerEntity>();
        public ICollection<ReviewEntity> Reviews { get; } = new List<ReviewEntity>();
    }
}
