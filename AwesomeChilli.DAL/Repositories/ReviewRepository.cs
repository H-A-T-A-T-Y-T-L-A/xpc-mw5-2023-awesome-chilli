using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.DAL.Repositories
{
    public class ReviewRepository : RepositoryBase<ReviewEntity>
    {
        public ReviewRepository(Database database) : base(database)
        {
        }
    }
}
