using System.Linq;

namespace Zammers.Models
{
    public class EFZammerRepo : IZammerRepo
    { //Class that uses the Interface IZammerRepo to set up the repo
        private BookstoreContext context { get; set; }
        public EFZammerRepo(BookstoreContext holder)
        {
            context = holder;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
