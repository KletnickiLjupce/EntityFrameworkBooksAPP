using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using EntityFrameworkBooksAPP.Models;
using System.Data.Entity;

namespace EntityFrameworkBooksAPP.DAL
{
    public class AuthorRepository : IAuthorRepository, IDisposable
    {
        private BookContext context;

        public AuthorRepository(BookContext context)
        {
            this.context = context;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return context.Authors.ToList();
        }

        public Author GetAuthorByID(int id)
        {
            return context.Authors.Find(id); 
        }

        public void InsertAuthor(Author author)
        {
            context.Authors.Add(author);
        }

        public void DeleteAuthor(int AuthorID)
        {
            Author author = context.Authors.Find(AuthorID);
            context.Authors.Remove(author);
        }

        public void UpdateAuthor(Author author)
        {
            context.Entry(author).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}