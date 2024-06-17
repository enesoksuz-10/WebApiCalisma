using Microsoft.EntityFrameworkCore;
using North_Model.Concreate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace North_DataAccess.Context
{
    public class NorthwndContext : DbContext
    {
        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Enes;Database=NORTHWND;Trusted_Connection=True");
        }
    }
}
