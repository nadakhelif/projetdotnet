﻿using Microsoft.AspNetCore.Mvc;
using projet_dotnet.Models;
using projet_dotnet.Data;
using System.Net;
using static System.Reflection.Metadata.BlobBuilder;
using System.Data;

namespace projet_dotnet.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            BookRepository bookRepository = new BookRepository();
            List<Book> books= bookRepository.all();
            ViewData["booksList"] = books;
            return View();
        }
        [HttpGet]
        public IActionResult ByMatiere(string matiere)
        {
            
            BookRepository bookRepository = new BookRepository();
            List<Book> l = bookRepository.BooksByMatiere(matiere);
            ViewData["matiere"] = matiere;
            ViewData["booksList"] = l;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BookContext bookContext = BookContext.Instantiate_Book_Context();
                    BookRepository bookRepository = new BookRepository(bookContext);
                    bookRepository.Add(book);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(book);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            BookContext bookContext = BookContext.Instantiate_Book_Context();          
            Book book = bookContext.Book.Find(id);
            ViewData["book"] = book;
            return View();
        }
        public IActionResult Delete(int id)
        {
            BookContext bookContext = BookContext.Instantiate_Book_Context();
            BookRepository bookRepository = new BookRepository(bookContext);
            bookRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
