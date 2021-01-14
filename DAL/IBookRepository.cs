using System;
using System.Collections.Generic;
using EntityFrameworkBooksAPP.Models;

namespace EntityFrameworkBooksAPP.DAL
{
    public interface IBookRepository: IDisposable
    {
        IEnumerable<Book> GetBooks();
        Book GetBookByID(int BookID);
        void InsertBook(Book book);
        void DeleteBook(int BookID);
        void UpdateBook(Book book);
        void Save();
    }
}