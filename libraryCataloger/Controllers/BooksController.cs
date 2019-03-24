using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using libraryCataloger.Models;

namespace libraryCataloger.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BooksController : Controller
    {
        private libraryCatalogerContext db = new libraryCatalogerContext();

        public ActionResult Index(string searchTitle, string searchAuthor, string searchPublisher)
        {
            if (searchTitle != "" || searchAuthor != "" || searchPublisher != "")
            {
                var books = db.Books.Include(h => h.BorrowHistories)
                    .Select(b => new BookViewModel
                    {
                        BookId = b.BookId,
                        Author = b.Author,
                        Publisher = b.Publisher,
                        Title = b.Title,
                        IsAvailable = !b.BorrowHistories.Any(h => h.ReturnDate == null)
                    }).Where(x => x.Title.Contains(searchTitle) || searchTitle == null)
                    .Where(x => x.Author.Contains(searchAuthor) || searchAuthor == null)
                    .Where(x => x.Publisher.Contains(searchPublisher) || searchPublisher == null).ToList();
                return View(books);
            }
            else
            {
                var books = db.Books.Include(h => h.BorrowHistories)
                    .Select(b => new BookViewModel
                    {
                        BookId = b.BookId,
                        Author = b.Author,
                        Publisher = b.Publisher,
                        Title = b.Title,
                        IsAvailable = !b.BorrowHistories.Any(h => h.ReturnDate == null)
                    }).ToList();
                return View(books);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,Title,Author,Publisher")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,Title,Author,Publisher")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
