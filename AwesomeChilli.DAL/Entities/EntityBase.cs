﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeChilli.DAL.Entities
{
    internal class EntityBase : IEntity
    {
        public Guid Id { get; set; }
    }
}
