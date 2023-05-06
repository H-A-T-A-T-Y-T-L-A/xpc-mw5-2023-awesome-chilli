using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AwesomeChilli.DAL.Entities
{
    public abstract class EntityBase : IEntity
    {
        [Key]
        [Map(nameof(Id))]
        public Guid Id { get; set; }
    }
}
