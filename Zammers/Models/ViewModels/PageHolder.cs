using System;

namespace Zammers.Models.ViewModels
{
    public class PageHolder
    {
        //stores pagination related numbers
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; } 
        public int CurrentPage { get; set; }
        public int TotalPages => (int) Math.Ceiling((double) TotalNumBooks / BooksPerPage);
    }
}
