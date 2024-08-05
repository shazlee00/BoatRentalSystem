using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Core.Entities
{
    public class Country:BaseEntity
    {
        public Country()
        {
        }
        public Country(string name)
        {
            Name = name;
        }
    }
}
