using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazynexAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public User(string login, string pass, string fName, string lName)
        {
            Id = Guid.NewGuid();
            Login = login;
            Password = pass;
            Firstname = fName;
            Lastname = lName;
        }
    }
}
