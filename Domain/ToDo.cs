using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ToDo
    {
        public int Id { get; set; } 
        [Required]
        public string Text { get; set; }
        public DateTime createDate { get; set; }
        public bool Delete { get; set; }
        public ICollection<Category> Category { get; set; }
        public bool Done { get; set; }
        
    }
}
