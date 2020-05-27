using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Shop.Models;

namespace Online_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationContext _db;

        public UserController(ApplicationContext context)
        {
            _db = context;
        }
        [HttpGet("Goods")]
        public ActionResult<IEnumerable<Basket>> GetUserItems([FromBody]JWT jwt)
        {
            var userFromDb = _db.Users
                .FirstOrDefault(o => o.JWT.Value == jwt.Value);
            if (userFromDb == null)
                return NotFound("There is no such JWT");
            var userBasketFromDb = _db.UserBaskets
                .Where(ub => ub.UserLogin == userFromDb.Login)
                .Include(ub => ub.Basket)
                .ToList();
            var items = userBasketFromDb.Select(i => i.Basket);
            return new ObjectResult(items);

        }
        [HttpPost("addItems")]

        public ActionResult AddItemsToUserBasket([FromBody]JWTWithObject<List<string>> JWTWithItems)
        {
            var jwtFromDb = _db.JWTs
                .FirstOrDefault(o => o.Value == JWTWithItems.JwtValue);
            if (jwtFromDb == null)
                return NotFound("There is no such JWT");

            var userFromDB = _db.Users
                .FirstOrDefault(o => o.JWT == jwtFromDb);
                if(userFromDB == null)
                return NotFound("There is no such JWT");

            _db.Entry(userFromDB).Collection(u => u.UserBaskets).Load();

            foreach (var item in JWTWithItems.Object)
            {

                var itemFromDB = _db.Items.FirstOrDefault(b => b.Name == item);

                //if (itemFromDB == null)
                //    continue;
                //if (userFromDB.UserBaskets.FirstOrDefault(ub => ub.BasketId == itemFromDB.ID) != null)
                //    continue;
                var ub = new UserBasket
                {
                    UserLogin = userFromDB.Login,
                    BasketId = itemFromDB.ID
                };
                userFromDB.UserBaskets.Add(ub);
                itemFromDB.UserBaskets.Add(ub);
               
            }
            _db.SaveChanges();
            return Ok();
        }

    }
}