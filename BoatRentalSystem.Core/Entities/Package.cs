﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Core.Entities
{
    public class Package:BaseEntity
    {
        public Package()
        {
          
        }
        public Package(string name)
        {
            Name = name;
        }
    }
}
