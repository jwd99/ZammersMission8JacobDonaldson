using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Zammers.Models;
using Zammers.Models.ViewModels;

//Jacob Donaldson Mission 7
//Zammers Book Buying site
//2/16/2022

namespace Zammers.Controllers
{
    public class HomeController : Controller
    {
        private IZammerRepo repo;
        
        public HomeController (IZammerRepo holder)
        {//USes the Repo which sets up what we normally put here
            repo = holder;
        }

        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            var holder = new BooksViewModel
            {//Orders by title and skips based on which page number it is. It also grabs num of books based on pageSize
                Books = repo.Books
              .OrderBy(b => b.Title)
              .Skip((pageNum - 1) * pageSize)
              .Take(pageSize),

                PageHolder = new PageHolder
                {//Page number information to be sent to pagination helper and what not
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            return View(holder);
        }
    }
}
