using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Models
{
    public class Goods
    {
        public Guid ID { get; set; }
        public int Price { get; set; }
        
        public string Name { get; set; }

        public string Image { get; set; }

        public string Tag { get; set; }

        public virtual IList<UserBasket> UserBaskets { get; set; }

        public Goods()
        {
            UserBaskets = new List<UserBasket>();
        }

    }
}
