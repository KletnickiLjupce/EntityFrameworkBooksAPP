using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkBooksAPP.DAL;
using EntityFrameworkBooksAPP.Models;

namespace EntityFrameworkBooksAPP.Controllers
{
    public class HomeController : Controller
    {
        private BookContext db = new BookContext();

        public ActionResult Index(string searchString)
        {
            var books = db.Books.Include(b => b.Author);
            //return View(books.ToList());

            //=====================
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper())
                                       || s.Author.Name.ToUpper().Contains(searchString.ToUpper()));
                return View(books.ToList());

            }
            return View(books.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}