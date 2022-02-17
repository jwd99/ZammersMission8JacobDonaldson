using System.Linq;

namespace Zammers.Models
{
    public interface IZammerRepo
    {

        IQueryable<Book> Books { get; }
    }
}
