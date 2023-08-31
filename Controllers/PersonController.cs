using Microsoft.AspNetCore.Mvc;
using ProoviTöö.Data;
using ProoviTöö.Models;

namespace ProoviTöö.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly DatabaseContext _context;

        public PersonController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Person> GetArticles()
        {
            var persons = _context.Persons.ToList();
            return persons;
        }

        [HttpPost]
        public List<Person> PostArtikkel([FromBody] Person artikkel)
        {
            _context.Persons.Add(artikkel);
            _context.SaveChanges();
            return _context.Persons.ToList();
        }

        [HttpDelete("{id}")]
        public List<Person> DeleteArtikkel(int id)
        {
            var artikkel = _context.Persons.Find(id);

            if (artikkel == null)
            {
                return _context.Persons.ToList();
            }

            _context.Persons.Remove(artikkel);
            _context.SaveChanges();
            return _context.Persons.ToList();
        }

        //[HttpDelete("/kustuta2/{id}")]
        //public IActionResult DeleteArtikkel2(int id)
        //{
        //    var artikkel = _context.Persons.Find(id);

        //    if (artikkel == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Persons.Remove(artikkel);
        //    _context.SaveChanges();
        //    return NoContent();
        //}

        [HttpGet("{id}")]
        public ActionResult<Person> GetArtikkel(int id)
        {
            var artikkel = _context.Persons.Find(id);

            if (artikkel == null)
            {
                return NotFound();
            }

            return artikkel;
        }

    }
}
