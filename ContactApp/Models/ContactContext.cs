using Microsoft.EntityFrameworkCore;

namespace ContactApp.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {

        }
        
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Family" },
                new Category { CategoryId = 2, Name = "Friend" },
                new Category { CategoryId = 3, Name = "Work" },
                new Category { CategoryId = 4, Name = "Church" },
                new Category { CategoryId = 5, Name = "School" }
                );
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    FirstName = "Abby",
                    LastName = "Garmendia",
                    Phone = "1112223333",
                    Email = "gabby@gmail.com",
                    CategoryId = 2,
                    DateCreated = System.DateTime.Now

                },
                new Contact
                {
                    ContactId = 2,
                    FirstName = "Weston",
                    LastName = "Paulsen",
                    Phone = "1112223333",
                    Email = "wp@gmail.com",
                    CategoryId = 2,
                    DateCreated = System.DateTime.Now


                },
                new Contact
                {
                    ContactId = 3,
                    FirstName = "John",
                    LastName = "Wick",
                    Phone = "1112228883",
                    Email = "jonny@gmail.com",
                    CategoryId = 3,
                    DateCreated = System.DateTime.Now
                }
                ) ;
        }
    }
}
