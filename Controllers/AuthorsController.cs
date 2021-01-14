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
    public class AuthorsController : Controller
    {
        private IBookRepository bookRepository;
        private IAuthorRepository authorRepository;

        public AuthorsController()
        {
            this.bookRepository = new BookRepository(new BookContext());
            this.authorRepository = new AuthorRepository(new BookContext());
        }
        public AuthorsController(IBookRepository bookRepository, AuthorRepository authorRepository)
        {
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
        }


        //private BookContext db = new BookContext();

        // GET: Authors
        public ActionResult Index()
        {
            var books = from s in authorRepository.GetAuthors()
                        select s;
            return View(books.ToList());
        }

        // GET: Authors/Details/5
        public ActionResult Details(int id)
        {
            Author author = authorRepository.GetAuthorByID(id);
            return View(author);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuthorID,Name")] Author author)
        {
            if (ModelState.IsValid)
            {
                
                authorRepository.InsertAuthor(author);
                authorRepository.Save();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int id)
        {
           
            Author author = authorRepository.GetAuthorByID(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuthorID,Name")] Author author)
        {
            if (ModelState.IsValid)
            {
                authorRepository.UpdateAuthor(author);
                authorRepository.Save();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int id)
        {
            
            Author author = authorRepository.GetAuthorByID(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Author author = authorRepository.GetAuthorByID(id);
            authorRepository.DeleteAuthor(id);
            authorRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                authorRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
