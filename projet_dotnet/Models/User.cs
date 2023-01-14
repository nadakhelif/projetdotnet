namespace projet_dotnet.Models
{
    public class User
    {
        public User(int id, string Name, string Email, string Password)
        {
            this.Id = id;
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
            
        }
        public static int id_generator = 100;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
