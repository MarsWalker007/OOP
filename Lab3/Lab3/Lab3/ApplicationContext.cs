using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Film> Films { get; set; } = null!;

        public DbSet<Scenarist>? Scenarists { get; set; } = null!;
        public DbSet<Genre>? Genres { get; set; } = null!;
        public DbSet<FType>? Types { get; set; } = null!;

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Film.db");
        }

    }
}
