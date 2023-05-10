using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.DAL.Queries.GetByName
{
    public class GetByNameQuery<TEntity>
        where TEntity : class, IEntity, INamedEntity
    {
        private readonly Database database;

        public GetByNameQuery(Database database)
        {
            this.database = database;
        }

        public IEnumerable<TEntity> Execute(string name)
        {
            return database.Set<TEntity>().Where(entity => entity.Name.ToLower().Contains(name.ToLower()));
        }
    }
}
