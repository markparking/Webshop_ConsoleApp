using System;

namespace MyClassLibrary
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public bool VerifyCredentials(string username, string password)
        {
            return Username == username && Password == password;
        }
    }
}
