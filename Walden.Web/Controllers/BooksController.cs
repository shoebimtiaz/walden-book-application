using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Walden.Data.Models;
using Walden.Data.Services;

namespace Walden.Web.Controllers
{
   
    public class BooksController : Controller
    {
        private readonly IBookData _db;

        public BooksController(IBookData db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _db.GetBooks();
            return View(model);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _db.GetBookById(id);
            if (model.Id == 0)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _db.GetBookById(id);
            if (model.Id == 0)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.UpdateBook(book);
                return RedirectToAction("Details", new { id = book.Id });
            }
            return View(book);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.AddBook(book);
                TempData["Message"] = "You have added a new book";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete (int id)
        {
            var model = _db.GetBookById(id);
            if (model.Id == 0)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection formCollection)
        {
             _db.DeleteBook(id);
            return RedirectToAction("Index");
        }
    }
}
