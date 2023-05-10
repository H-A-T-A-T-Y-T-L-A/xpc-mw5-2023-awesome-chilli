using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.DAL.Repositories
{
    public class CommodityRepository : RepositoryBase<CommodityEntity>
    {
        public CommodityRepository(Database database) : base(database)
        {
        }
    }
}
