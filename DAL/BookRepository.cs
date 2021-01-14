using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using EntityFrameworkBooksAPP.Models;
using System.Data.Entity;

namespace EntityFrameworkBooksAPP.DAL
{
    public class BookRepository : IBookRepository, IDisposable
    {
        private BookContext context;

        public BookRepository(BookContext context)
        {
            this.context = context;
        }

        public IEnumerable<Book> GetBooks()
        {
            return context.Books.ToList();
        }

        public Book GetBookByID(int id)
        {
            return context.Books.Find(id);
        }

        //public Book GetBookAuthorID(int id)
        //{
        //    return context.Books;
        //}

        public void InsertBook(Book book)
        {
            context.Books.Add(book);
        }

        public void DeleteBook(int BookID)
        {
            Book book = context.Books.Find(BookID);
            context.Books.Remove(book);
        }

        public void UpdateBook(Book book)
        {
            context.Entry(book).State = EntityState.Modified;
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