using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Zammers.Models;
using Zammers.Models.ViewModels;

//Jacob Donaldson Mission 8
//Zammers Book Buying site
//2/24/2022

namespace Zammers.Controllers
{
    public class HomeController : Controller
    {
        private IZammerRepo repo;
        
        public HomeController (IZammerRepo holder)
        {//USes the Repo which sets up what we normally put here
            repo = holder;
        }

        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            int pageSize = 6;

            var holder = new BooksViewModel
            {//Orders by title and skips based on which page number it is. It also grabs num of books based on pageSize
                Books = repo.Books
              .Where(b => b.Category == bookCategory || bookCategory == null)
              .OrderBy(b => b.Title)
              .Skip((pageNum - 1) * pageSize)
              .Take(pageSize),
                //Added in where clause to bring in bookCategory info if not null.
                PageHolder = new PageHolder
                {//Page number information to be sent to pagination helper and what not
                    TotalNumBooks = (bookCategory == null
                    ? repo.Books.Count()
                    : repo.Books.Where(b => b.Category == bookCategory).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                    //if statement brings category if needed
                }
            };
            return View(holder);
        }
    }
}
