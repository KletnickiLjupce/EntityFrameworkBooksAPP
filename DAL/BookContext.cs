using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EntityFrameworkBooksAPP.Models;

namespace EntityFrameworkBooksAPP.DAL
{
    public class BookContext: DbContext

    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

     

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }       
}