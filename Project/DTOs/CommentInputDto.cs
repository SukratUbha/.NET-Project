using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.DTOs
{
    public class CommentInputDto
    {
        [Required]
        public string Comment { get; set; }
        
        public string Name { get; set; }
        //public string IP { get; set; }
    }
}
