using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Houses.Models.House
{
    public class HouseViewModel
    {
        public Guid? Id { get; set; }
        public string Address { get; set; }
        public int Area { get; set; }
        public int FloorsNumber { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
