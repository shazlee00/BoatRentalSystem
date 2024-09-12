using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Core.Entities
{
    public class Addition:BaseEntity
    {
        public Addition()
        {
        }
        public Addition(string name)
        {
            Name = name;
        }

        public int OwnerId { get; set; }
        public Owner Owner { get; set; }  
        public string Description { get; set; } 
        public double Price { get; set; }        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }


    }
}
