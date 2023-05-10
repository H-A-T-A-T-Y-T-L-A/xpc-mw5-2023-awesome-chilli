using AwesomeChilli.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeChilli.DAL.Queries
{
    public class GetCommodityByCategoryQuery
    {
        private readonly Database database;

        public GetCommodityByCategoryQuery(Database database)
        {
            this.database = database;
        }

        public IEnumerable<CommodityEntity> Execute(Guid id)
        {
            return database.Commodities.Where(commodity => commodity.Category != null && commodity.Category.Id == id);
        }
    }
}
