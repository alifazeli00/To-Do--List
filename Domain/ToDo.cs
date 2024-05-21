using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ToDo
    {
        public int Id { get; set; } 
        public string Text { get; set; }
        public DateTime createDate { get; set; }
        public bool Remove { get; set; }
        public ICollection<Category> Category { get; set; }
    }
}
