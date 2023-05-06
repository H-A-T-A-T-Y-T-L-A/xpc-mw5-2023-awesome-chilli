using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.DAL.Queries
{
    public class GetAllQuery<TEntity> where TEntity : class, IEntity
    {
        private readonly Database database;

        public GetAllQuery(Database database)
        {
            this.database = database;
        }

        public IEnumerable<TEntity> Execute()
        {
            return database.Set<TEntity>();
        }
    }
}
