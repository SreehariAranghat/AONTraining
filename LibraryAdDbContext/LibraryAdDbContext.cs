using Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAdDbContext
{
    public class LibraryAdDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }  

        public DbSet<Book> Books { get; set; }

        public DbSet<RentalRecord> RentalRecords { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            //optionsBuilder.EnableSensitiveDataLogging();
            //optionsBuilder.LogTo((log) => Console.WriteLine(log));
            optionsBuilder.UseSqlServer("Server=tcp:aranghat.database.windows.net,1433;Initial Catalog=AonTraining;Persist Security Info=False;User ID=rootadmin;Password=Matrix1234$$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                         .HasData(new User
                         {   Id = 1,
                             Name = "Sree",
                             Email = "sreehariis@gmail.com" ,
                             CreatedDate = DateTime.Now,
                             Password = "abcd@1234"
                         });

            modelBuilder.Entity<Book>()
                .HasData(new Book { Id =1, Description = "", Name = "Monk Who sold his ferrari", Author = "Robin Sharma", Title = "Monk Who sold his ferrari", CreatedDate = DateTime.Now }
                        , new Book { Id=2, Description = "", Name = "Dracula", Author = "Bram Stocker", Title = "Dracula", CreatedDate = DateTime.Now });
        }
    }
}
