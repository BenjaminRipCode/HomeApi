using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly HomeContext _context;

        public HomeController(HomeContext context)
        {
            _context = context;

            if (_context.Homes.Count() == 0)
            {
                _context.Homes.Add(new HomeItem ());
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<HomeItem>> GetAll()
        {
            return _context.Homes.ToList();
        }

        [HttpGet("{id}", Name = "GetHome")]
        public ActionResult<HomeItem> GetById(long id)
        {
            var item = _context.Homes.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(HomeItem home)
        {
            _context.Homes.Add(home);
            _context.SaveChanges();

            return CreatedAtRoute("GetHome", new { id = home.Id }, home);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var home = _context.Homes.Find(id);
            if (home == null)
            {
                return NotFound();
            }

            _context.Homes.Remove(home);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
