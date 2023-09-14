using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Project.Models
{
    public class comments
    {
        [Key]
        public int ID { get; set; }
        public string Time { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public string Name { get; set; }
        public string IP { get; set; }

    }
}
