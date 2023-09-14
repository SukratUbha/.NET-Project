using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Project.DTOs
{
    public class CommentOutDto
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Time { get; set; }


        public string IP { get; set; }
    }
}
