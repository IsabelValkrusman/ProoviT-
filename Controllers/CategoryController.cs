using Microsoft.AspNetCore.Mvc;
using ProoviTöö.Data;
using ProoviTöö.Models;

namespace ProoviTöö.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly DatabaseContext _context;

        public CategoryController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Category> GetArticles()
        {
            var categorys = _context.Categorys.ToList();
            return categorys;
        }

        [HttpPost]
        public List<Category> PostArtikkel([FromBody] Category artikkel)
        {
            _context.Categorys.Add(artikkel);
            _context.SaveChanges();
            return _context.Categorys.ToList();
        }

        [HttpDelete("{id}")]
        public List<Category> DeleteArtikkel(int id)
        {
            var artikkel = _context.Categorys.Find(id);

            if (artikkel == null)
            {
                return _context.Categorys.ToList();
            }

            _context.Categorys.Remove(artikkel);
            _context.SaveChanges();
            return _context.Categorys.ToList();
        }

        //[HttpDelete("/kustuta2/{id}")]
        //public IActionResult DeleteArtikkel2(int id)
        //{
        //    var artikkel = _context.Categorys.Find(id);

        //    if (artikkel == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Categorys.Remove(artikkel);
        //    _context.SaveChanges();
        //    return NoContent();
        //}

        [HttpGet("{id}")]
        public ActionResult<Category> GetArtikkel(int id)
        {
            var artikkel = _context.Categorys.Find(id);

            if (artikkel == null)
            {
                return NotFound();
            }

            return artikkel;
        }
    }
}
