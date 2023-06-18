using AcademyProjectEntity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyProjectEntity.Contexts
{
    public class AcademyDBcontextt:DbContext
    {
        public DbSet<Group> groups { get; set; }
        public DbSet<Student> studentss { get; set; }   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Server=DESKTOP-2S0R6OF\\SQLEXPRESS;Database=AcademyDb;Trusted_Connection=True";
            optionsBuilder.UseSqlServer(connection);
        }
    }
}
