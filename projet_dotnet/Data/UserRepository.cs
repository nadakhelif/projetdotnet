﻿using projet_dotnet.Models;
using System.Net;

namespace projet_dotnet.Data
{
    public class UserRepository
    {
        public UserRepository(BookContext biblio)
        {
            this.biblio = biblio;
        }

        BookContext biblio;
        public static User currentUser { get; set; }
        public void AddUser(string Filiere, int Niveau, string LastName, string FirstName, string Email, string Password)
        {
            User.id_generator++;
            var Id = User.id_generator;
            User u = new User(Id, Filiere, Niveau, LastName, FirstName, Email, Password);
            biblio.User.Add( u );   
            biblio.SaveChanges();
        }
        public void UpdateUser(string Name, string Email, string Password)
        {

            //User u = context.User.Find(UserRepository.currentUser.Id);
            currentUser.FirstName= Name ;
            currentUser.Email = Email;
            currentUser.Password = Password;
            biblio.SaveChanges();
        }
        public void Deleteuser(int id)
        {
            User u=biblio.User.Find(id) ;
            biblio.Remove(u) ;
            biblio.SaveChanges();
        }



    }
}
