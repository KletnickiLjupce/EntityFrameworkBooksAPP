using System;
using System.Collections.Generic;
using EntityFrameworkBooksAPP.Models;

namespace EntityFrameworkBooksAPP.DAL
{
    public interface IAuthorRepository: IDisposable
    {
        IEnumerable<Author> GetAuthors();
        Author GetAuthorByID(int AuthorID);
        void InsertAuthor(Author author);
        void DeleteAuthor(int AuthorID);
        void UpdateAuthor(Author author);
        void Save();
    }
}