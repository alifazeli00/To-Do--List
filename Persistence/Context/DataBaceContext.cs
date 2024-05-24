using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class DataBaceContext : DbContext
    {
        //
        public DataBaceContext(DbContextOptions<DataBaceContext> options) : base(options)
        {

        }
        public DbSet<Category> Categoryes { get; set; }
        public DbSet<ToDo> ToDos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ToDo>().HasQueryFilter(p => !p.Remove);
        }


    }
}
