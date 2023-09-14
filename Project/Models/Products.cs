using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
        public class Product  //Create the table model here
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public double Price { get; set; }

        }
}
