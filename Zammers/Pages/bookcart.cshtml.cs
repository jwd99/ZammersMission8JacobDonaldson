using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using Zammers.Infastructure;
using Zammers.Models;

namespace Zammers.Pages
{
    public class bookcartModel : PageModel
    {
        private IZammerRepo repo { get; set; }
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }
        public bookcartModel (IZammerRepo temp, Basket b)
        {//why do I do this. I think it is to create a new model based on the repo?
            repo = temp;
            basket = b;
        }
    
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            
        }
        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);
         
            basket.AddItem(b, 1);

            return RedirectToPage(new {ReturnUrl = returnUrl});
        }
        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
