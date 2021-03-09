using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftwareEngineeringProject.Models;

namespace SoftwareEngineeringProject.Controllers
{
    [Route("Books")]
    public class BooksController : Controller
    {

        [Route("")]
        [HttpGet]
        public IActionResult Index()

        {

            var db = new software_engineering_projectContext();
            return View(MapBooks(db.Books.ToList()));
        }

        [Route("Add")]
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "Add book";
            return View("Edit",null);
        }


        [Route("Edit")]
        [HttpPost]
        public IActionResult Edit(int bookId, Books book)
        {
            var db = new software_engineering_projectContext();
            var book_db = db.Books.FirstOrDefault(x => x.BookId == bookId);
            if (book_db != null)
            {
                book_db.Author = book.Author;
                book_db.Description = book.Description;
                book_db.Name = book.Name;
                book_db.Price = book.Price;
                book_db.Thumbnail = book.Thumbnail;
            }
            else
            {
                db.Books.Add(new Books()
                {
                    Author = book.Author,
                    Name = book.Name,
                    Price = book.Price,
                    Description = book.Description,
                    Thumbnail = book.Thumbnail
                });
            }

            db.SaveChanges();

            return RedirectToActionPermanent("Index", "Books");
        }

        [Route("Edit/{ID}")]
        [HttpGet]
        public IActionResult Edit(int bookId)
        {

            var db = new software_engineering_projectContext();
            var book_db = db.Books.FirstOrDefault(x => x.BookId == bookId);

            return View("Edit", book_db);


        }

        private BookViewModel MapBooks(List<Books> books)
        {
            if (books == null) return null;

            return new BookViewModel()
            {
                Books = books,
                User = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("User"))
            };
        }


    }
}
