using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MagazynexAPI.Models;

namespace MagazynexAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly User[] Users = new[]
        {
            new User("admin", "admin123!", "Pan", "Admin"),
            new User("jkowal", "zaq1@WSX", "Jan", "Kowalski"),
            new User("snowak", "xsw2#EDC", "Szymon", "Nowak"),
            new User("awanna", "cde3$RFV", "Anna", "Wanna")
        };

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/getUserInfo/{id}")]
        public User GetUserInfo([FromRoute]Guid id)
        {
            User user = null;
            foreach(var u in Users)
            {
                if(u.Id == id)
                {
                    user = u;
                }
            }
            user.Password = "";
            return user;
        }

        [HttpGet]
        [Route("/login/{login}")]
        public IActionResult Login([FromRoute]string login, [FromBody]string password)
        {
            bool loggedIn = false;
            string id = "";
            foreach (var user in Users)
            {
                if (user.Login == login && user.Password == password)
                {
                    loggedIn = true;
                    id = user.Id.ToString();
                    break;
                }
            }

            if (loggedIn)
            {
                return Ok(id);
            }
            else
            {
                return NotFound("Wrong login or password");
            }
        }
    }
}
