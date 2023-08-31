using Microsoft.AspNetCore.Mvc;
using ProoviTöö.Data;
using ProoviTöö.Models;

namespace ProoviTöö.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartProductController : Controller
    {
        private readonly DatabaseContext _context;

        public CartProductController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<CartProduct> GetArticles()
        {
            var cartProducts = _context.CartProducts.ToList();
            return cartProducts;
        }

        [HttpPost]
        public List<CartProduct> PostArtikkel([FromBody] CartProduct artikkel)
        {
            _context.CartProducts.Add(artikkel);
            _context.SaveChanges();
            return _context.CartProducts.ToList();
        }

        [HttpDelete("{id}")]
        public List<CartProduct> DeleteArtikkel(int id)
        {
            var artikkel = _context.CartProducts.Find(id);

            if (artikkel == null)
            {
                return _context.CartProducts.ToList();
            }

            _context.CartProducts.Remove(artikkel);
            _context.SaveChanges();
            return _context.CartProducts.ToList();
        }

        [HttpDelete("/kustuta2/{id}")]
        public IActionResult DeleteArtikkel2(int id)
        {
            var artikkel = _context.CartProducts.Find(id);

            if (artikkel == null)
            {
                return NotFound();
            }

            _context.CartProducts.Remove(artikkel);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<CartProduct> GetArtikkel(int id)
        {
            var artikkel = _context.CartProducts.Find(id);

            if (artikkel == null)
            {
                return NotFound();
            }

            return artikkel;
        }


    }
}
