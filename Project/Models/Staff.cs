using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{   public class Staff  //Create the table model here
        {
            public int ID { get; set; }
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string Title { get; set; }
            public string Email { get; set; }
            public string Tel { get; set; }
            public string Url { get; set; }
            public string Research { get; set; }

        }
}
