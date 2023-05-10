using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.DAL.Repositories
{
    public class ManufacturerRepository : RepositoryBase<ManufacturerEntity>
    {
        public ManufacturerRepository(Database database) : base(database)
        {
        }
    }
}
