using Microsoft.AspNetCore.Mvc;
using projet_dotnet.Models;
using projet_dotnet.Data;
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
    }
}
