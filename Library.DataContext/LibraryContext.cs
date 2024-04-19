using Library.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataContext
{
    public class LibraryContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<Log> Logs { get; set; }
          
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(
            options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasQueryFilter(d => d.DeletedDate == null)
                        .HasIndex(d => d.Email);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                    .UseNpgsql("");

        }*/
    }
}
