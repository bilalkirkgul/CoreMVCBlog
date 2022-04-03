using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Database yolunu belirttik.
            optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS01; database=CoreBlogApiDB2022; uid=bilal; pwd=123");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
