using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Shop.Models;

namespace Online_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private readonly ApplicationContext _db;

        public GoodsController(ApplicationContext context)
        {
            _db = context;
        }
        [HttpGet]
        public IEnumerable<Goods> GetGoods()
        {
            return _db.Items.ToArray();
        }

        [HttpPost("{goods}")]
        public ActionResult CreateItem([FromBody]Goods item)
        {
            var itemFromDB = _db.Items.Select(o => o.Name).ToArray();
            if (itemFromDB.Contains(item.Name))
            {
                return BadRequest("This item already exists");
            }

            var newItem = new Goods
            {
                ID = Guid.NewGuid(),
                Name = item.Name,
                Price = item.Price,
                Tag = item.Tag

            };
            var itemBasket = new Basket
            {
                ID = Guid.NewGuid(),
                Name = item.Name,
                Price = item.Price,
                Amount = 1,
            };
            _db.Baskets.Add(itemBasket);
            _db.Items.Add(newItem);
            _db.SaveChanges();
            return Ok(newItem);

        }
        [HttpDelete("{goods}")]
        public ActionResult<Goods> DeleteItem([FromBody]Goods item)
        {
            var itemFromDB = _db.Items.FirstOrDefault(f => f.Name == item.Name);
            if (itemFromDB == null)
            {
                return NotFound("There is no such item");
            }
            _db.Remove(itemFromDB);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPut("{goods}")]
        public ActionResult<Goods> UpdateItem([FromBody]Goods item)
        {

            var itemFromDB = _db.Items.FirstOrDefault(f => f.Name == item.Name);
            if (itemFromDB == null)
                return NotFound("This item does not exist");
            itemFromDB.Price = item.Price;

            _db.SaveChanges();
            return Ok();

        }
    }
}
