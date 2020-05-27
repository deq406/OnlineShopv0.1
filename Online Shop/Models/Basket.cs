using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Shop.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Online_Shop.Models
{
    [DataContract]
    public class Basket
    {
        [DataMember]
        public Guid ID { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }

        public int Amount { get; set; }

        public virtual IList<UserBasket> UserBaskets { get; set; }

        public Basket()
        {
            UserBaskets = new List<UserBasket>();
        }


    }
}
