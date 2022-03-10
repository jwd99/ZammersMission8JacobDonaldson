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

        public void SaveBook(Book b)
        {
            context.SaveChanges();
        }

        public void CreateBook(Book b)
        {
            context.Add(b);
            context.SaveChanges();
        }

        public void DeleteBook(Book b)
        {
            context.Remove(b);
            context.SaveChanges();
        }
    }
}
