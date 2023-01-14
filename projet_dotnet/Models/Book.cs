using System.ComponentModel.DataAnnotations;

namespace projet_dotnet.Models
{
    public class Book
    {
        [Key]
        public int book_id { get; set; }
        public string book_title { get; set; }
    }
}
