using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDetails_Test.Models
{
    public class CarData
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CarName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> New { get; set; }
    }
}