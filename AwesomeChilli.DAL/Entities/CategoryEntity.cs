﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeChilli.DAL.Entities
{
    public class CategoryEntity : EntityBase
    {
        [Map(nameof(Name))]
        public string Name { get; set; } = "";

        public ICollection<CommodityEntity> Commodities { get; set; } = new List<CommodityEntity>();
    }
}
