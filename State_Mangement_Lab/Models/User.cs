using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace State_Mangement_Lab.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }


        public User(string userName, string email, string password, int age)
        {
            UserName = UserName;
            Email = email;
            Password = password;
            Age = age;
        }

        public User() { }

    }
}