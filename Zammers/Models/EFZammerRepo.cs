using System.Linq;

namespace Zammers.Models
{
    public class EFZammerRepo : IZammerRepo
    {
        private BookstoreContext context { get; set; }
        public EFZammerRepo(BookstoreContext holder)
        {
            context = holder;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
