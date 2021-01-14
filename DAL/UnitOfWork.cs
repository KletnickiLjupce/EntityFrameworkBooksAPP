using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityFrameworkBooksAPP.Models;

namespace EntityFrameworkBooksAPP.DAL
{
    //public class UnitOfWork : IDisposable
    //{
    //    private BookContext context = new BookContext();
    //    private GenericRepository<Book> BookRepository();
    //    private GenericRepository<Author> authorRepository();

    //    public GenericRepository<Book> BookRepository
    //    {
    //        get
    //        {

    //            if (this.BookRepository == null)
    //            {
    //                this.BookRepository = new GenericRepository<Book>(context);
    //            }
    //            return BookRepository;
    //        }
    //    }

    //    public GenericRepository<Author> authorRepository
    //    {
    //        get
    //        {

    //            if (this.authorRepository == null)
    //            {
    //                this.courseRepository = new GenericRepository<Author>(context);
    //            }
    //            return authorRepository;
    //        }
    //    }

    //    public void Save()
    //    {
    //        context.SaveChanges();
    //    }

    //    private bool disposed = false;

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!this.disposed)
    //        {
    //            if (disposing)
    //            {
    //                context.Dispose();
    //            }
    //        }
    //        this.disposed = true;
    //    }

    //    public void Dispose()
    //    {
    //        Dispose(true);
    //        GC.SuppressFinalize(this);
    //    }



    //}
}