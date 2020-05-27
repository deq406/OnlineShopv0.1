using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Online_Shop.Models.Interfaces
{
    [DataContract]
    public class User : IUser
    {
        [Required(ErrorMessage ="User must have a login")]
        [StringLength(maximumLength:20,MinimumLength =2)]
        [DataMember]
        public string Login { get; set; }
        [Required(ErrorMessage = "User must have a password")]
        [StringLength(maximumLength:100,MinimumLength =5,ErrorMessage ="Password length should be in diaposon[5;100]")]
        
        [DataMember]
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public JWT JWT { get; set; }
        
        public int Role { get; set; }

        public virtual IList<UserBasket> UserBaskets { get; set; }

        public User()
        {
            UserBaskets = new List<UserBasket>();
        }



    }
}
