﻿using Domain.Models.BaseEntitiyModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Entities
{
    public class District : District_baseEntities
    {
        public int ID { get; set; }
       // public object Id { get; set; }
        public string Name { get; set; }
        //public string AddedBy { get; set; }
       
             public string? AddedBy { get; set; } // Nullable
       
            public string? UpdatedBy { get; set; } // Nullable
        }

    }

