using System.Linq;

namespace Zammers.Models.ViewModels
{
    public class BooksViewModel
    {
        public IQueryable<Book> Books  { get; set; }
        public PageHolder PageHolder { get; set; }
    }
}
