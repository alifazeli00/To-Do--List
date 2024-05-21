using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Todo
{
    public class TodoDto
    {
        public int Id { get; set; }
        [Required]
        public string Text  { get; set; }
        public DateTime createDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
