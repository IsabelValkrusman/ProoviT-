using Microsoft.AspNetCore.Mvc;
using ProoviTöö.Data;
using ProoviTöö.Models;

namespace ProoviTöö.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly DatabaseContext _context;

        public ProductController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Product> GetArticles()
        {
            var cartProducts = _context.Products.ToList();
            return cartProducts;
        }

        [HttpPost]
        public List<Product> PostArtikkel([FromBody] Product artikkel)
        {
            _context.Products.Add(artikkel);
            _context.SaveChanges();
            return _context.Products.ToList();
        }

        [HttpDelete("{id}")]
        public List<Product> DeleteArtikkel(int id)
        {
            var artikkel = _context.Products.Find(id);

            if (artikkel == null)
            {
                return _context.Products.ToList();
            }

            _context.Products.Remove(artikkel);
            _context.SaveChanges();
            return _context.Products.ToList();
        }

        //[HttpDelete("/kustuta2/{id}")]
        //public IActionResult DeleteArtikkel2(int id)
        //{
        //    var artikkel = _context.CartProducts.Find(id);

        //    if (artikkel == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.CartProducts.Remove(artikkel);
        //    _context.SaveChanges();
        //    return NoContent();
        //}

        [HttpGet("{id}")]
        public ActionResult<Product> GetArtikkel(int id)
        {
            var artikkel = _context.Products.Find(id);

            if (artikkel == null)
            {
                return NotFound();
            }

            return artikkel;
        }
    }
}
