using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MagazynexAPI.Models;
using System.Text.Json;
using AutoMapper;

namespace MagazynexAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;

        private static readonly User[] Users = new[]
        {
            new User("admin", "admin123!", "Pan", "Admin"),
            new User("jkowal", "zaq1@WSX", "Jan", "Kowalski"),
            new User("snowak", "xsw2#EDC", "Szymon", "Nowak"),
            new User("awanna", "cde3$RFV", "Anna", "Wanna")
        };

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/getUserInfo/{id}")]
        public IActionResult GetUserInfo([FromRoute]Guid id)
        {
            foreach(var user in Users)
            {
                if(user.Id == id)
                {
                    var userDto = _mapper.Map<UserGetInfoDto>(user);
                    return Ok(JsonSerializer.Serialize(userDto));
                }
            }

            return NotFound("User not found");
        }

        [HttpGet]
        [Route("/login/{password}")]
        public IActionResult Login([FromRoute] string password)
        {
            foreach (var user in Users)
            {
                if (user.Password == password)
                {
                    var userDto = _mapper.Map<UserLogInDto>(user);
                    return Ok(JsonSerializer.Serialize(userDto));
                }
            }
            
            return NotFound("Wrong login or password");
        }
    }
}
