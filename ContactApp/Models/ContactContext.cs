using Microsoft.EntityFrameworkCore;

namespace ContactApp.Models
{
    public class ContactContext : DbContext
    {
        //constructor that takes in options from the dbcontextoptions
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {

        }
        //creates a db set (table) named Contacts
        public DbSet<Contact> Contacts { get; set; }
        //creates a db set (table) named Categories

        public DbSet<Category> Categories { get; set; }
        /// <summary>
        /// generates starting data for the tables.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //creates a modelBuilder
            base.OnModelCreating(modelBuilder);
            //Model builder chooses  category and enters the data
            modelBuilder.Entity<Category>().HasData(
                //each row is in an instance of the Category Class with specific values
                new Category { CategoryId = 1, Name = "Family" },
                new Category { CategoryId = 2, Name = "Friend" },
                new Category { CategoryId = 3, Name = "Work" },
                new Category { CategoryId = 4, Name = "Church" },
                new Category { CategoryId = 5, Name = "School" }
                );
            //Model builder chooses a Contact and enters the data

            modelBuilder.Entity<Contact>().HasData(
                    //each row is in an instance of the Category Class with specific values
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
