using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task123.Models;

namespace Task123.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        ApplicationDbContext _context;
        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void Post([FromBody] User user)
        {
            _context.Add(new User {FirstName = user.FirstName, Age=user.Age });
            _context.SaveChanges();
        }
        
        [HttpPut]
        public void Put(int id,[FromBody] User user)
        {
            User _user = _context.Users.Find(id);
            _user.FirstName = user.FirstName;
            _user.Age = user.Age;
            _context.Users.Update(_user);
            _context.SaveChanges();
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _context.Users.Find(id);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            User user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
