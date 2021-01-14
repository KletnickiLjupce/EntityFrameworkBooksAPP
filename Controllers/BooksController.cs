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
    public class BooksController : Controller
    {
        private IBookRepository bookRepository;
        private IAuthorRepository authorRepository;

        public BooksController()
        {
            this.bookRepository = new BookRepository(new BookContext());
            this.authorRepository = new AuthorRepository(new BookContext());
        }
        public BooksController(IBookRepository bookRepository , AuthorRepository authorRepository)
        {
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
        }


        // private BookContext db = new BookContext();

        // GET: Books
        public ActionResult Index()
        {
            //var books = db.Books.Include(b => b.Author);
            var books = from s in bookRepository.GetBooks()
                        select s;
            return View(books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Book book = db.Books.Find(id);
            //var book = from s in bookRepository.GetBookByID(int ?id)
            //            select s;

            Book book = bookRepository.GetBookByID(id);

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            //ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Name");
            ViewBag.AuthorID = new SelectList(authorRepository.GetAuthors(), "AuthorID", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookID,Name,Count,AuthorID")] Book book)
        {
            if (ModelState.IsValid)
            {
                //db.Books.Add(book);
                //db.SaveChanges();

                bookRepository.InsertBook(book);
                bookRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(authorRepository.GetAuthors(), "AuthorID", "Name", book.AuthorID);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            //Book book = db.Books.Find(id);

            Book book = bookRepository.GetBookByID(id);
            ViewBag.AuthorID = new SelectList(authorRepository.GetAuthors(), "AuthorID", "Name", book.AuthorID);
            return View(book);

            //if (book == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Name", book.AuthorID);
            //return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookID,Name,Count,AuthorID")] Book book)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(book).State = EntityState.Modified;
                //db.SaveChanges();
                bookRepository.UpdateBook(book);
                bookRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(authorRepository.GetAuthors(), "AuthorID", "Name", book.AuthorID);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            //Book book = db.Books.Find(id);
            Book book = bookRepository.GetBookByID(id);

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Book book = db.Books.Find(id);
            //db.Books.Remove(book);
            //db.SaveChanges();
            //return RedirectToAction("Index");

            try
            {
                Book book = bookRepository.GetBookByID(id);
                bookRepository.DeleteBook(id);
                bookRepository.Save();
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();

                bookRepository.Dispose();
                authorRepository.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
