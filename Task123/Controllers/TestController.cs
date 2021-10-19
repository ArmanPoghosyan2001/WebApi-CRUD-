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
        public void Post([FromBody] string name)
        {
            User user = new User
            {
                FirstName = name,
                Age = 18
            };
            _context.Add(user);
            _context.SaveChanges();
        }
        
        [HttpPut]
        public void Put(int id,[FromBody] string name)
        {
            User user = _context.Users.Find(id);
            user.FirstName = name;
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        [HttpGet]
        public IEnumerable<string> GetNames()
        {
            return _context.Users.Select(x => x.FirstName).ToList();
        }

        [HttpGet("{id}")]
        public string GetName(int id)
        {
            return _context.Users.Find(id).FirstName;
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
