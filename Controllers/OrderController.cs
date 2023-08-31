using Microsoft.AspNetCore.Mvc;
using ProoviTöö.Data;
using ProoviTöö.Models;

namespace ProoviTöö.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly DatabaseContext _context;

        public OrderController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Order> GetArticles()
        {
            var orders = _context.Orders.ToList();
            return orders;
        }

        [HttpPost]
        public List<Order> PostArtikkel([FromBody] Order artikkel)
        {
            _context.Orders.Add(artikkel);
            _context.SaveChanges();
            return _context.Orders.ToList();
        }

        [HttpDelete("{id}")]
        public List<Order> DeleteArtikkel(int id)
        {
            var artikkel = _context.Orders.Find(id);

            if (artikkel == null)
            {
                return _context.Orders.ToList();
            }

            _context.Orders.Remove(artikkel);
            _context.SaveChanges();
            return _context.Orders.ToList();
        }

        //[HttpDelete("/kustuta2/{id}")]
        //public IActionResult DeleteArtikkel2(int id)
        //{
        //    var artikkel = _context.Orders.Find(id);

        //    if (artikkel == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Orders.Remove(artikkel);
        //    _context.SaveChanges();
        //    return NoContent();
        //}

        [HttpGet("{id}")]
        public ActionResult<Order> GetArtikkel(int id)
        {
            var artikkel = _context.Orders.Find(id);

            if (artikkel == null)
            {
                return NotFound();
            }

            return artikkel;
        }
    }
}
