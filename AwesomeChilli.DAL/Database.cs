using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.DAL
{
    public class Database
    {
        public ICollection<CommodityEntity> Commodities { get; } = new List<CommodityEntity>();
        public ICollection<CategoryEntity> Categories { get; } = new List<CategoryEntity>();
        public ICollection<ManufacturerEntity> Manufacturers { get; } = new List<ManufacturerEntity>();
        public ICollection<ReviewEntity> Reviews { get; } = new List<ReviewEntity>();
    }
}
