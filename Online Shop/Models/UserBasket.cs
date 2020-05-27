using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Shop.Models.Interfaces;

namespace Online_Shop.Models
{
    public class UserBasket
    {
        public string UserLogin { get; set; }
        public User User { get; set; }

        public Guid BasketId { get; set; }
        public Basket Basket { get; set; }

        
    }
}
