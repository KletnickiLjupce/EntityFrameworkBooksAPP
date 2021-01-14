namespace EntityFrameworkBooksAPP.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EntityFrameworkBooksAPP.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityFrameworkBooksAPP.DAL.BookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        

        protected override void Seed(EntityFrameworkBooksAPP.DAL.BookContext context)
        {

             var authors = new List<Author>
            {
                new Author{Name="J. R. R. Tolkien",AuthorID=1},
                new Author{Name="J. K. Rowling",AuthorID=2},
            };
            authors.ForEach(s => context.Authors.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var books = new List<Book>
            {
                new Book {Name="The Lord of the Rings",BookID=1,AuthorID=1,Count=10},
                new Book {Name="The Hobbit",BookID=2,AuthorID=1,Count=2},
                new Book {Name="Harry Potter and the Philosopher's Stone",BookID=3,AuthorID=2,Count=6},
                new Book {Name="Harry Potter and the Deathly Hallows",BookID=4,AuthorID=2,Count=4},
            };
            books.ForEach(s => context.Books.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();




            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
