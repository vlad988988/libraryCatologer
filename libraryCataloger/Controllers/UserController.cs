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
    public class UserController : Controller
    {
        private libraryCatalogerContext db = new libraryCatalogerContext();

        public ActionResult Index(string searchTitle, string searchAuthor, string searchPublisher)
        {
            if (searchTitle != "" || searchAuthor != "" || searchPublisher != "")
            {
                var books = db.Books
                    .Select(b => new BookViewModel
                    {
                        BookId = b.BookId,
                        Author = b.Author,
                        Publisher = b.Publisher,
                        Title = b.Title
                    }).Where(x => x.Title.Contains(searchTitle) || searchTitle == null)
                    .Where(x => x.Author.Contains(searchAuthor) || searchAuthor == null)
                    .Where(x => x.Publisher.Contains(searchPublisher) || searchPublisher == null).ToList();
                return View(books);
            }
            else
            {
                var books = db.Books
                    .Select(b => new BookViewModel
                    {
                        BookId = b.BookId,
                        Author = b.Author,
                        Publisher = b.Publisher,
                        Title = b.Title
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
