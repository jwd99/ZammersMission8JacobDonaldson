﻿using System.Linq;

namespace Zammers.Models
{
    public interface IZammerRepo
    { //Helps ensure the classes are created according to proper methods

        IQueryable<Book> Books { get; }
        void SaveBook(Book b);
        void CreateBook(Book b);
        void DeleteBook(Book b);
    }
}
