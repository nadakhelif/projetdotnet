using projet_dotnet.Models;

namespace projet_dotnet.Data
{
    public class BookRepository
    {
        public List<Book> all()
        {
            BookContext bc = BookContext.Instantiate_Book_Context();
            var books = bc.Book;
            if (books == null) { return new List<Book>(); }
            else return books.ToList();
        }
    }
}
