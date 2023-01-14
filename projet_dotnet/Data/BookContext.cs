using Microsoft.EntityFrameworkCore;
using projet_dotnet.Models;
using System.Diagnostics;
namespace projet_dotnet.Data
{
    public class BookContext :DbContext
    {
        static private BookContext bookContextInstance = null;
        public DbSet<Book>? Book { get; set; }
        public BookContext(DbContextOptions o) : base(o) { }
        public static BookContext Instantiate_Book_Context()
        {
            if (bookContextInstance == null)
            {

                var optionsBuilder = new DbContextOptionsBuilder<BookContext>();
                optionsBuilder.UseSqlite(@"Data Source=C:\Users\Nada\source\repos\projet_dotnet\projet_dotnet\book.db");
                bookContextInstance = new BookContext(optionsBuilder.Options);
                Debug.WriteLine("instance created for the first time");
                return bookContextInstance;
            }
            else
            {
                Debug.WriteLine("instance already created");
                return bookContextInstance;
            }
        }

    }
}
