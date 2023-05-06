using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeChilli.DAL.Entities
{
    public abstract class EntityBase : IEntity
    {
        [Map(nameof(Id))]
        public Guid Id { get; set; }
    }
}
