using System;
using System.Collections.Generic;
using System.Text;
using Walden.Data.Models;

namespace Walden.Data.Services
{
    public interface IBookData
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById(int id);
        void UpdateBook(Book book);
        void AddBook(Book book);
        void DeleteBook(int id);
    }
}
