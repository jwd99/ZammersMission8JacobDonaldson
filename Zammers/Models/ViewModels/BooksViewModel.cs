using System.Linq;

namespace Zammers.Models.ViewModels
{
    public class BooksViewModel
    {
        //Brings the two parts together
        public IQueryable<Book> Books  { get; set; }
        public PageHolder PageHolder { get; set; }
    }
}
