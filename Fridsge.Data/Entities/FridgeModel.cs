﻿using Fridge.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fridsge.Data.Entities
{
    public class FridgeModel : BaseEntity
    {
        public string Name { get; set; }
        public int year { get; set; }
        public virtual Fridge Fridge { get; set; }
    }
}
